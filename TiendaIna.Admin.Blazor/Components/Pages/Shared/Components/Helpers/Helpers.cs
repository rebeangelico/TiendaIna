using Radzen;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components.Helpers {
    public static class HelpersComponents {
        private static readonly NotificationService _notificationService;

        static HelpersComponents() {
            _notificationService = new NotificationService();
        }

        static void NotifySuccess(string message) =>
        _notificationService.Notify(NotificationSeverity.Success, "Éxito", message);

        static void NotifyError(string context, Exception ex) =>
            _notificationService.Notify(NotificationSeverity.Error, "Error", $"{context}: {ex.Message}");




    }
}
