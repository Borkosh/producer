using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Producer.pplService;
using WCFExtensions.Dispatcher;
namespace Producer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PeopleRegister" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PeopleRegister.svc or PeopleRegister.svc.cs at the Solution Explorer and start debugging.
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [DispatchByBodyElementBehavior]
    public class PeopleRegister : pplService.person_register
    {
        [DispatchBodyElement("personList", "http://persons_register.x-road.ee")]

        public personListResponse personList(personListRequest request)
        {
            if (request.lastName == "Torgoev") { 
                return new personListResponse

                {
                    client = request.client,
                    service = request.service,
                    id = request.id,
                    protocolVersion = request.protocolVersion,
                    userId = request.userId,

                        person = new person
                        {
                            birthDate = DateTime.Now,
                            firstName = "Ilgiz",
                            lastName = "Torgoev",
                            personContact = new contact
                            {
                                address = "Chuy 12",
                                email = new[]{
                                    "juhan@ee.ee","juhan2@ee.ee","juha3n@ee.ee"
                                },
                                phone = new[]{
                                    "0701444444","0701222222","0701333333"
                                }
                            }
                        }
                };
            }
            else
            {
                return new personListResponse();
            }
        }

    }
}
