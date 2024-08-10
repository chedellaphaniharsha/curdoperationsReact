namespace webapi.Models
{
    public class UserDetails
    {
        public int ID { get; set; }
        public string   Username { get; set; }
        public string   password { get; set; }
        public string   EmailId { get; set; }
        public string   BloadGru { get; set; }
        public DateTime CreateAT { get; set; }
        public DateTime UpdateAT { get; set; }
  //      public int Isupdate { get; set; }   
       public IFormFile Userfile { get; set; }
    }
}
