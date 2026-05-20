using projetbtsblanc.Models;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetbtsblanc.Models
{
    public class Medecin : Personne
    {

        private string rpps;
        private string email;
        private string password;

        public string getRpps() { return this.rpps; }
        public string getEmail() { return this.email; }
        public string getPassword() { return this.password; }

        public void setRpps(string newRpps) { this.rpps = newRpps; }
        public void setEmail(string newEmail) { this.email = newEmail; }
        public void setPassword(string newPassword) { this.password = newPassword; }
        
        public Medecin () {

        }
        public Medecin(string rpps, string email, string password)// string name, string firstname, string birthdate)
        {
            //:base(name, firstname, birthdate)
            this.rpps = rpps;
            this.email = email;
            this.password = password;
        }

    }
  
}