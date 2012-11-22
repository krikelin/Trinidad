using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JariZ;
using Trinidad.Controllers.Players;
namespace Trinidad.Controllers.Players
{
    class Spotify : IPlayer
    {
        private JariZ.SpotifyAPI API = new SpotifyAPI(SpotifyAPI.GetOAuth(), "7194.spotilocal.com");
        Responses.CFID cfid;
        Responses.Status Current_Status;
        public override string ToString()
        {
            return Name;
        }
        public String Name
        {
            get
            {
                return "Spotify";
            }
        }
        public Spotify()
        {
            cfid = API.CFID;
            Current_Status = API.Status;
        }

        public void Pause()
        {
            Current_Status = API.Pause; 
           
        }

        public void Play()
        {
            Current_Status = API.Resume;
        }


        public void FadeIn()
        {
            throw new NotImplementedException();
        }

        public int Volume
        {
            get
            {
                return 255;
            }
            set
            {
               
            }
        }

        public int MaxVolume
        {
            get { return 255; }
        }

        public void FadeOut()
        {
            
        }
    }
}
