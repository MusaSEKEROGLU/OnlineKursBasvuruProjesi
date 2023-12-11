namespace KursBasvuruCoreMvc.WebUI.Models
{
    public static class Repository
    {
        //Veirler InMemory tutulacak uygulama kapandığında kaybolacak DB yok

        private static List<Candidate> applications = new ();
        public static IEnumerable<Candidate> Applications => applications;

        public static void Add(Candidate candidate)
        {
            applications.Add(candidate);
        }
    }
}
