namespace GuardApp.Model.HelperModel
{
    public class PersonalViewModal
    {
        public int PersonalId { get; set; }
        public string Name { get; set; }
        public int RankNumber { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
