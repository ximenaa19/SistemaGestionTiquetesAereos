using System;
using MySqlConnector;

namespace GestionAerolineas.src.Shared.Helpers;

public class MySqlVersionResolver
{
    public static Version DetectVersion(string connectionString)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();
        var raw = conn.ServerVersion;
        if (raw == null)
        {
            throw new InvalidOperationException("Unable to retrieve server version.");
        }
        var clean = raw.Split('-')[0];
        return Version.Parse(clean);
    }
}

