namespace TiendaIna.Core.Models {
    public class AppSettings {
        public class ConnectionStringsSection {
            public string? SqlServer { get; set; }
        }

        public ConnectionStringsSection? ConnectionStrings { get; set; }
        public bool InMemoryRepos { get; set; }
    }
}
