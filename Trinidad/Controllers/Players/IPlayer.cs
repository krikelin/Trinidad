using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinidad.Controllers.Players
{
    /// <summary>
    /// A music player to control
    /// </summary>
    public interface IPlayer
    {
        String Name
        {
            get;
        }
        void Pause();
        void Play();
        
    }
}
