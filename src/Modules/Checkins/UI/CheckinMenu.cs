using System.Globalization;
using GestionAerolineas.src.Modules.CheckinStatuses.Application.UseCases;
using GestionAerolineas.src.Modules.Checkins.Application.UseCases;
using GestionAerolineas.src.Modules.Checkins.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightSeats.Application.UseCases;
using GestionAerolineas.src.Modules.FlightSeats.Domain.Aggregate;
using GestionAerolineas.src.Modules.Flights.Application.UseCases;
using GestionAerolineas.src.Modules.Passengers.Application.UseCases;
using GestionAerolineas.src.Modules.People.Application.UseCases;
using GestionAerolineas.src.Modules.ReservationFlights.Application.UseCases;
using GestionAerolineas.src.Modules.ReservationPassengers.Application.UseCases;
using GestionAerolineas.src.Modules.Staff.Application.UseCases;
using GestionAerolineas.src.Modules.Tickets.Application.UseCases;

namespace GestionAerolineas.src.Modules.Checkins.UI;

public class CheckinMenu
{
    private const int TopCount = 10;

    private readonly CreateCheckinUseCase _create;
    private readonly GetAllCheckinsUseCase _getAll;
    private readonly GetCheckinByIdUseCase _getById;
    private readonly GetCheckinByTicketIdUseCase _getByTicketId;
    private readonly GetCheckinsByPassengerIdUseCase _getByPassengerId;
    private readonly GetCheckinsByFlightIdUseCase _getByFlightId;
    private readonly GetCheckinsByStatusIdUseCase _getByStatusId;
    private readonly GetCheckinsByCheckedAtRangeUseCase _getByCheckedAtRange;
    private readonly UpdateCheckinUseCase _update;
    private readonly DeleteCheckinUseCase _delete;

    private readonly GetAllTicketsUseCase _getAllTickets;
    private readonly GetAllCheckinStatusesUseCase _getAllStatuses;
    private readonly GetAllStaffUseCase _getAllStaff;
    private readonly GetAvailableSeatsByFlightIdUseCase _getAvailableSeatsByFlightId;
    private readonly GetAllFlightSeatsUseCase _getAllFlightSeats;
    private readonly GetAllFlightsUseCase _getAllFlights;
    private readonly GetAllReservationPassengersUseCase _getAllReservationPassengers;
    private readonly GetAllReservationFlightsUseCase _getAllReservationFlights;
    private readonly GetAllPassengersUseCase _getAllPassengers;
    private readonly GetAllPeopleUseCase _getAllPeople;

    public CheckinMenu(
        CreateCheckinUseCase create,
        GetAllCheckinsUseCase getAll,
        GetCheckinByIdUseCase getById,
        GetCheckinByTicketIdUseCase getByTicketId,
        GetCheckinsByPassengerIdUseCase getByPassengerId,
        GetCheckinsByFlightIdUseCase getByFlightId,
        GetCheckinsByStatusIdUseCase getByStatusId,
        GetCheckinsByCheckedAtRangeUseCase getByCheckedAtRange,
        UpdateCheckinUseCase update,
        DeleteCheckinUseCase delete,
        GetAllTicketsUseCase getAllTickets,
        GetAllCheckinStatusesUseCase getAllStatuses,
        GetAllStaffUseCase getAllStaff,
        GetAvailableSeatsByFlightIdUseCase getAvailableSeatsByFlightId,
        GetAllFlightSeatsUseCase getAllFlightSeats,
        GetAllFlightsUseCase getAllFlights,
        GetAllReservationPassengersUseCase getAllReservationPassengers,
        GetAllReservationFlightsUseCase getAllReservationFlights,
        GetAllPassengersUseCase getAllPassengers,
        GetAllPeopleUseCase getAllPeople)
    {
        _create = create;
        _getAll = getAll;
        _getById = getById;
        _getByTicketId = getByTicketId;
        _getByPassengerId = getByPassengerId;
        _getByFlightId = getByFlightId;
        _getByStatusId = getByStatusId;
        _getByCheckedAtRange = getByCheckedAtRange;
        _update = update;
        _delete = delete;
        _getAllTickets = getAllTickets;
        _getAllStatuses = getAllStatuses;
        _getAllStaff = getAllStaff;
        _getAvailableSeatsByFlightId = getAvailableSeatsByFlightId;
        _getAllFlightSeats = getAllFlightSeats;
        _getAllFlights = getAllFlights;
        _getAllReservationPassengers = getAllReservationPassengers;
        _getAllReservationFlights = getAllReservationFlights;
        _getAllPassengers = getAllPassengers;
        _getAllPeople = getAllPeople;
    }

    public async Task StartAsync()
    {
        var menu = new ConsoleMenu(new[]
        {
            "Create a check-in",
            "List all check-ins",
            "Get check-in by ID",
            "Get check-in by tiquete_id",
            "Get check-ins by passenger_id",
            "Get check-ins by vuelo_id",
            "Get check-ins by estado_checkin_id",
            "Get check-ins by fecha_checkin range",
            "Update a check-in",
            "Delete a check-in",
            "Exit"
        });

        while (true)
        {
            int option = menu.Show();

            try
            {
                switch (option)
                {
                    case 0:
                        var ticketMap = await GetTicketMapAsync();
                        await PrintTicketsAsync(ticketMap);
                        await PrintAirportStaffAsync();
                        await PrintStatusesAsync();

                        Console.Write("\nIngrese tiquete_id: ");
                        int ticketId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese personal_id: ");
                        int staffId = int.Parse(Console.ReadLine()!);

                        var flightId = await TryResolveFlightIdFromTicketAsync(ticketId);
                        if (flightId is null)
                            throw new Exception("No se pudo resolver el vuelo del ticket (revisa reserva_pasajero/reserva_vuelo)");

                        await PrintAvailableSeatsForFlightAsync(flightId.Value);
                        Console.Write("Ingrese asiento_vuelo_id: ");
                        int seatId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese fecha_checkin (yyyy-MM-dd HH:mm) [default=now]: ");
                        var checkedAtInput = Console.ReadLine();
                        DateTime? checkedAt = string.IsNullOrWhiteSpace(checkedAtInput)
                            ? null
                            : DateTime.Parse(checkedAtInput!, CultureInfo.InvariantCulture);

                        Console.Write("Ingrese estado_checkin_id: ");
                        int statusId = int.Parse(Console.ReadLine()!);

                        Console.Write("Equipaje bodega? (0/1) [default=0]: ");
                        var bagInput = Console.ReadLine();
                        bool hasBag = (bagInput ?? string.Empty).Trim() == "1";

                        decimal? weight = 0m;
                        if (hasBag)
                        {
                            Console.Write("Peso equipaje (kg): ");
                            weight = decimal.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                        }

                        var created = await _create.ExecuteAsync(
                            ticketId,
                            staffId,
                            seatId,
                            checkedAt,
                            statusId,
                            hasBag,
                            weight);

                        Console.WriteLine($"✔ Check-in creado: id={created.Id.Value}, boardingPass={created.BoardingPassNumber.Value}");
                        break;

                    case 1:
                        await PrintListAsync(await _getAll.ExecuteAsync());
                        break;

                    case 2:
                        Console.Write("Ingrese el ID: ");
                        int id = int.Parse(Console.ReadLine()!);

                        var byId = await _getById.ExecuteAsync(id);
                        if (byId is null)
                        {
                            Console.WriteLine("No encontrado");
                            break;
                        }

                        await PrintListAsync(new[] { byId });
                        break;

                    case 3:
                        var map = await GetTicketMapAsync();
                        await PrintTicketsAsync(map);

                        Console.Write("\nIngrese tiquete_id: ");
                        int tId = int.Parse(Console.ReadLine()!);

                        var byTicket = await _getByTicketId.ExecuteAsync(tId);
                        if (byTicket is null)
                        {
                            Console.WriteLine("(sin registros)");
                            break;
                        }

                        await PrintListAsync(new[] { byTicket });
                        break;

                    case 4:
                        await PrintPassengersAsync();
                        Console.Write("\nIngrese passenger_id: ");
                        int passengerId = int.Parse(Console.ReadLine()!);

                        await PrintListAsync(await _getByPassengerId.ExecuteAsync(passengerId));
                        break;

                    case 5:
                        await PrintFlightsAsync();
                        Console.Write("\nIngrese vuelo_id: ");
                        int flightIdInput = int.Parse(Console.ReadLine()!);

                        await PrintListAsync(await _getByFlightId.ExecuteAsync(flightIdInput));
                        break;

                    case 6:
                        await PrintStatusesAsync();
                        Console.Write("\nIngrese estado_checkin_id: ");
                        int statusIdInput = int.Parse(Console.ReadLine()!);

                        await PrintListAsync(await _getByStatusId.ExecuteAsync(statusIdInput));
                        break;

                    case 7:
                        Console.Write("Desde (yyyy-MM-dd): ");
                        var from = DateTime.ParseExact(Console.ReadLine()!, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        Console.Write("Hasta (yyyy-MM-dd): ");
                        var to = DateTime.ParseExact(Console.ReadLine()!, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                            .AddDays(1)
                            .AddTicks(-1);

                        await PrintListAsync(await _getByCheckedAtRange.ExecuteAsync(from, to));
                        break;

                    case 8:
                        var ticketMap2 = await GetTicketMapAsync();
                        await PrintTicketsAsync(ticketMap2);
                        await PrintAirportStaffAsync();
                        await PrintStatusesAsync();

                        Console.Write("\nIngrese el ID: ");
                        int updId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese tiquete_id: ");
                        int updTicketId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese personal_id: ");
                        int updStaffId = int.Parse(Console.ReadLine()!);

                        var updFlightId = await TryResolveFlightIdFromTicketAsync(updTicketId);
                        if (updFlightId is null)
                            throw new Exception("No se pudo resolver el vuelo del ticket");

                        await PrintAvailableSeatsForFlightAsync(updFlightId.Value);
                        Console.Write("Ingrese asiento_vuelo_id: ");
                        int updSeatId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese fecha_checkin (yyyy-MM-dd HH:mm): ");
                        var updCheckedAt = DateTime.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

                        Console.Write("Ingrese estado_checkin_id: ");
                        int updStatusId = int.Parse(Console.ReadLine()!);

                        Console.Write("Numero tarjeta embarque (ENTER para mantener): ");
                        var bp = Console.ReadLine();

                        Console.Write("Equipaje bodega? (0/1) [default=0]: ");
                        var updBagInput = Console.ReadLine();
                        bool updHasBag = (updBagInput ?? string.Empty).Trim() == "1";

                        decimal? updWeight = 0m;
                        if (updHasBag)
                        {
                            Console.Write("Peso equipaje (kg): ");
                            updWeight = decimal.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                        }

                        await _update.ExecuteAsync(
                            updId,
                            updTicketId,
                            updStaffId,
                            updSeatId,
                            updCheckedAt,
                            updStatusId,
                            bp,
                            updHasBag,
                            updWeight);

                        Console.WriteLine("✔ Actualizado");
                        break;

                    case 9:
                        Console.Write("Ingrese el ID: ");
                        int delId = int.Parse(Console.ReadLine()!);

                        await _delete.ExecuteAsync(delId);
                        Console.WriteLine("✔ Eliminado");
                        break;

                    case 10:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.GetBaseException().Message}");
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private async Task PrintListAsync(IEnumerable<Checkin> list)
    {
        var statuses = await GetStatusMapAsync();
        var ticketMap = await GetTicketMapAsync();
        var staffMap = await GetStaffMapAsync();
        var seatMap = await GetSeatMapAsync();

        var items = list.ToList();
        if (items.Count == 0)
        {
            Console.WriteLine("(sin registros)");
            return;
        }

        foreach (var item in items)
            Console.WriteLine(Format(item, statuses, ticketMap, staffMap, seatMap));
    }

    private async Task PrintStatusesAsync()
    {
        var statuses = await _getAllStatuses.ExecuteAsync();
        Console.WriteLine("CheckinStatuses:");
        foreach (var s in statuses)
            Console.WriteLine($"{s.Id.Value} - {s.Name.Value}");
    }

    private async Task PrintAirportStaffAsync()
    {
        var staff = (await _getAllStaff.ExecuteAsync())
            .Where(s => s.IsActive.Value && s.AirportId.Value is not null)
            .OrderBy(s => s.Id.Value)
            .ToList();

        var peopleMap = await GetPeopleNameMapForStaffAsync(staff.Select(s => s.PersonId.Value).ToList());

        Console.WriteLine("Staff (airport, active) (top 10):");
        foreach (var s in staff.Take(TopCount))
        {
            var name = peopleMap.TryGetValue(s.PersonId.Value, out var n) ? n : $"#{s.PersonId.Value}";
            Console.WriteLine($"{s.Id.Value} - {name} - airport_id={s.AirportId.Value}");
        }

        Console.Write("Buscar personal (texto) [opcional]: ");
        var search = (Console.ReadLine() ?? string.Empty).Trim();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.ToUpperInvariant();
            var matches = staff
                .Select(s =>
                {
                    var name = peopleMap.TryGetValue(s.PersonId.Value, out var n) ? n : string.Empty;
                    return new { s, key = $"{name} {s.Id.Value}".ToUpperInvariant() };
                })
                .Where(x => x.key.Contains(normalized))
                .Select(x => x.s)
                .Take(TopCount)
                .ToList();

            Console.WriteLine("\nCoincidencias (top 10):");
            if (matches.Count == 0)
                Console.WriteLine("(sin registros)");
            else
                foreach (var s in matches)
                {
                    var name = peopleMap.TryGetValue(s.PersonId.Value, out var n) ? n : $"#{s.PersonId.Value}";
                    Console.WriteLine($"{s.Id.Value} - {name} - airport_id={s.AirportId.Value}");
                }
        }
    }

    private async Task PrintPassengersAsync()
    {
        var passengers = (await _getAllPassengers.ExecuteAsync()).ToList();
        var people = (await _getAllPeople.ExecuteAsync()).ToList();
        var nameByPersonId = people.ToDictionary(p => p.Id.Value, p => $"{p.FirstNames.Value} {p.LastNames.Value}");

        Console.WriteLine("Passengers (top 10):");
        foreach (var p in passengers.Take(TopCount))
        {
            var name = nameByPersonId.TryGetValue(p.PersonId.Value, out var n) ? n : $"#{p.PersonId.Value}";
            Console.WriteLine($"{p.Id.Value} - {name}");
        }

        Console.Write("Buscar pasajero (texto) [opcional]: ");
        var search = (Console.ReadLine() ?? string.Empty).Trim();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.ToUpperInvariant();
            var matches = passengers
                .Select(p =>
                {
                    var name = nameByPersonId.TryGetValue(p.PersonId.Value, out var n) ? n : string.Empty;
                    return new { p, key = $"{name} {p.Id.Value}".ToUpperInvariant() };
                })
                .Where(x => x.key.Contains(normalized))
                .Select(x => x.p)
                .Take(TopCount)
                .ToList();

            Console.WriteLine("\nCoincidencias (top 10):");
            if (matches.Count == 0)
                Console.WriteLine("(sin registros)");
            else
                foreach (var p in matches)
                {
                    var name = nameByPersonId.TryGetValue(p.PersonId.Value, out var n) ? n : $"#{p.PersonId.Value}";
                    Console.WriteLine($"{p.Id.Value} - {name}");
                }
        }
    }

    private async Task PrintFlightsAsync()
    {
        var flights = (await _getAllFlights.ExecuteAsync())
            .OrderByDescending(f => f.Id.Value)
            .Take(TopCount)
            .ToList();

        Console.WriteLine("Flights (top 10):");
        foreach (var f in flights)
            Console.WriteLine($"{f.Id.Value} - {f.Code.Value} - dep={f.DepartureDateTime.Value:yyyy-MM-dd HH:mm}");
    }

    private async Task PrintAvailableSeatsForFlightAsync(int flightId)
    {
        var seats = (await _getAvailableSeatsByFlightId.ExecuteAsync(flightId))
            .OrderBy(s => s.Code.Value)
            .Take(TopCount)
            .ToList();

        Console.WriteLine($"FlightSeats disponibles (top 10) para vuelo_id={flightId}:");
        if (seats.Count == 0)
        {
            Console.WriteLine("(sin registros)");
            return;
        }

        foreach (var s in seats)
            Console.WriteLine($"{s.Id.Value} - {s.Code.Value} - occupied={s.IsOccupied.Value}");
    }

    private async Task PrintTicketsAsync(Dictionary<int, string> ticketMap)
    {
        var checkins = (await _getAll.ExecuteAsync()).ToList();
        var usedTicketIds = checkins.Select(c => c.TicketId.Value).ToHashSet();

        var items = ticketMap
            .Where(kv => !usedTicketIds.Contains(kv.Key))
            .OrderByDescending(kv => kv.Key)
            .Take(TopCount)
            .ToList();

        Console.WriteLine("Tickets sin check-in (top 10):");
        if (items.Count == 0)
        {
            Console.WriteLine("(sin registros)");
            return;
        }

        foreach (var kv in items)
            Console.WriteLine($"{kv.Key} - {kv.Value}");

        Console.Write("Buscar ticket (texto) [opcional]: ");
        var search = (Console.ReadLine() ?? string.Empty).Trim();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.ToUpperInvariant();
            var matches = ticketMap
                .Where(kv => !usedTicketIds.Contains(kv.Key))
                .Where(kv => kv.Value.ToUpperInvariant().Contains(normalized))
                .OrderByDescending(kv => kv.Key)
                .Take(TopCount)
                .ToList();

            Console.WriteLine("\nCoincidencias (top 10):");
            if (matches.Count == 0)
                Console.WriteLine("(sin registros)");
            else
                foreach (var kv in matches)
                    Console.WriteLine($"{kv.Key} - {kv.Value}");
        }
    }

    private async Task<Dictionary<int, string>> GetStatusMapAsync()
    {
        var statuses = await _getAllStatuses.ExecuteAsync();
        return statuses.ToDictionary(s => s.Id.Value, s => s.Name.Value);
    }

    private async Task<int?> TryResolveFlightIdFromTicketAsync(int ticketId)
    {
        var tickets = (await _getAllTickets.ExecuteAsync()).ToList();
        var reservationPassengers = (await _getAllReservationPassengers.ExecuteAsync()).ToList();
        var reservationFlights = (await _getAllReservationFlights.ExecuteAsync()).ToList();

        var ticket = tickets.FirstOrDefault(t => t.Id.Value == ticketId);
        if (ticket is null)
            return null;

        var rp = reservationPassengers.FirstOrDefault(rp => rp.Id.Value == ticket.ReservationPassengerId.Value);
        if (rp is null)
            return null;

        var rf = reservationFlights.FirstOrDefault(rf => rf.Id.Value == rp.ReservationFlightId.Value);
        return rf?.FlightId.Value;
    }

    private async Task<Dictionary<int, string>> GetTicketMapAsync()
    {
        var tickets = (await _getAllTickets.ExecuteAsync()).ToList();
        var reservationPassengers = (await _getAllReservationPassengers.ExecuteAsync()).ToList();
        var reservationFlights = (await _getAllReservationFlights.ExecuteAsync()).ToList();
        var flights = (await _getAllFlights.ExecuteAsync()).ToList();
        var passengers = (await _getAllPassengers.ExecuteAsync()).ToList();
        var people = (await _getAllPeople.ExecuteAsync()).ToList();

        var rpById = reservationPassengers.ToDictionary(rp => rp.Id.Value, rp => rp);
        var rfById = reservationFlights.ToDictionary(rf => rf.Id.Value, rf => rf);
        var flightById = flights.ToDictionary(f => f.Id.Value, f => f);
        var passengerById = passengers.ToDictionary(p => p.Id.Value, p => p);
        var personNameById = people.ToDictionary(p => p.Id.Value, p => $"{p.FirstNames.Value} {p.LastNames.Value}");

        var map = new Dictionary<int, string>();
        foreach (var t in tickets)
        {
            var pax = "NULL";
            var flightCode = "NULL";

            if (rpById.TryGetValue(t.ReservationPassengerId.Value, out var rp) &&
                passengerById.TryGetValue(rp.PassengerId.Value, out var passenger) &&
                personNameById.TryGetValue(passenger.PersonId.Value, out var name))
                pax = $"{name} [{rp.PassengerId.Value}]";

            if (rpById.TryGetValue(t.ReservationPassengerId.Value, out var rp2) &&
                rfById.TryGetValue(rp2.ReservationFlightId.Value, out var rf) &&
                flightById.TryGetValue(rf.FlightId.Value, out var f))
                flightCode = $"{f.Code.Value} [{rf.FlightId.Value}]";

            map[t.Id.Value] = $"code={t.Code.Value} - pax={pax} - flight={flightCode} - reserva_pasajero_id={t.ReservationPassengerId.Value}";
        }

        return map;
    }

    private async Task<Dictionary<int, string>> GetStaffMapAsync()
    {
        var staff = (await _getAllStaff.ExecuteAsync()).ToList();
        var people = (await _getAllPeople.ExecuteAsync()).ToList();
        var personNameById = people.ToDictionary(p => p.Id.Value, p => $"{p.FirstNames.Value} {p.LastNames.Value}");

        var result = new Dictionary<int, string>();
        foreach (var s in staff)
        {
            var name = personNameById.TryGetValue(s.PersonId.Value, out var n) ? n : $"#{s.PersonId.Value}";
            result[s.Id.Value] = $"{name} - active={(s.IsActive.Value ? 1 : 0)} - airport_id={s.AirportId.Value?.ToString() ?? "NULL"}";
        }

        return result;
    }

    private async Task<Dictionary<int, string>> GetSeatMapAsync()
    {
        var seats = (await _getAllFlightSeats.ExecuteAsync()).ToList();
        var flights = (await _getAllFlights.ExecuteAsync()).ToList();

        var flightCodeById = flights.ToDictionary(f => f.Id.Value, f => f.Code.Value);

        return seats.ToDictionary(
            s => s.Id.Value,
            s =>
            {
                var flightCode = flightCodeById.TryGetValue(s.FlightId.Value, out var c) ? c : $"#{s.FlightId.Value}";
                return $"{flightCode} - {s.Code.Value} - occupied={(s.IsOccupied.Value ? 1 : 0)}";
            });
    }

    private async Task<Dictionary<int, string>> GetPeopleNameMapForStaffAsync(List<int> personIds)
    {
        var people = (await _getAllPeople.ExecuteAsync())
            .Where(p => personIds.Contains(p.Id.Value))
            .ToList();

        return people.ToDictionary(p => p.Id.Value, p => $"{p.FirstNames.Value} {p.LastNames.Value}");
    }

    private static string Format(
        Checkin c,
        Dictionary<int, string> statusMap,
        Dictionary<int, string> ticketMap,
        Dictionary<int, string> staffMap,
        Dictionary<int, string> seatMap)
    {
        var status = statusMap.TryGetValue(c.StatusId.Value, out var st) ? $"{st} [{c.StatusId.Value}]" : $"#{c.StatusId.Value}";
        var ticket = ticketMap.TryGetValue(c.TicketId.Value, out var tk) ? $"{tk} [{c.TicketId.Value}]" : $"#{c.TicketId.Value}";
        var staff = staffMap.TryGetValue(c.StaffId.Value, out var sf) ? $"{sf} [{c.StaffId.Value}]" : $"#{c.StaffId.Value}";
        var seat = seatMap.TryGetValue(c.FlightSeatId.Value, out var s) ? $"{s} [{c.FlightSeatId.Value}]" : $"#{c.FlightSeatId.Value}";
        var dt = c.CheckedAt.Value.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

        return $"{c.Id.Value} - ticket={ticket} - staff={staff} - seat={seat} - checkedAt={dt} - status={status} - boardingPass={c.BoardingPassNumber.Value} - bag={(c.HasHoldBaggage.Value ? 1 : 0)} - kg={c.BaggageWeightKg.Value:0.00}";
    }
}
