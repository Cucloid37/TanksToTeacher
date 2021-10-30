using System.Collections.Generic;
using TANKS.Start;

namespace TANKS
{
    public class EventController : IInitialization
    {
        private readonly IEnumerable<IDoIt> _getActionObjects;

        public EventController(IEnumerable<IDoIt> getActionObjects)
        {
            _getActionObjects = getActionObjects;
        }
        
        public void Initialization()
        {
            foreach (var variable in _getActionObjects)
            {
                variable.OnTriggerEnterChange += 
            }    
        }
    }
}