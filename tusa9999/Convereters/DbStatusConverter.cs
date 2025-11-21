using Party.WebApi.Model;

namespace Party.WebApi.Convereters;

internal static class DbStatusConverter
{
    public static DbStatus ConvertToRepository(ApiStatus status)
    {
        return status switch
        {
            ApiStatus.Invited => DbStatus.Invited,
            ApiStatus.NotInvited => DbStatus.NotInvited,
            ApiStatus.WaitingForInvite => DbStatus.WaitingForInvite,
            ApiStatus.Blacklist => DbStatus.Blacklist
        };
    }
}
