using Meetup.BussinesLogic.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BussinessLogic.Test
{
    public class User_Should
    {

        IUsuarioController controller;

        public User_Should(IUsuarioController controller)
        {
            this.controller = controller;
        }

        public async Task User_ShouldSignUp() {

            //var user = controller.SignUp();

        }

        public async Task User_ShouldLogin() { 
        }

        public async Task User_ShouldRegisterToMeetup() { 
            

        }

        public async Task User_ShouldCheckIn() { 
        
        }

        public async Task User_ShouldAddTopic() { 
            

        }


    }
}
