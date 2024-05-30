using Syncfusion.Blazor.Popups;

namespace GRA.App.Helpers
{
    public static class AppHelpers
    {
        public static async Task<bool> DisplayMessage(bool flag, string message, SfDialogService dialogService)
        {
            if (flag)
            {
                await dialogService.AlertAsync(message, "Opération réussite");
                return true;
            }
            else
            {
                await dialogService.AlertAsync(message, "Alerte!");
                return false;
            }
        }
    }
}