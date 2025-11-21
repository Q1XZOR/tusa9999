using Party.WebApi.Model;

namespace Party.WebApi.Convereters;

internal static class ApiStatusConverter
{

    public static ApiStatus ConvertToInterface(DbStatus status)
    {
        return status switch
        {
            DbStatus.Invited => ApiStatus.Invited,
            DbStatus.NotInvited => ApiStatus.NotInvited,
            DbStatus.WaitingForInvite => ApiStatus.WaitingForInvite,
            DbStatus.Blacklist => ApiStatus.Blacklist
        }; 
    }
 
        
}

        


