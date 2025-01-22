using BulutSistem.Domain.Models;


namespace BulutSistem.Appllication.Constants;

public static class Constants
{
    public static List<AppRole> GetRoles()
    {
        List<string> roles = new()
    {
        "Admin",
        "Editör",
        "Viewer"
    };

        return roles.Select(s => new AppRole() { Name = s }).ToList();
    }
}
