using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class MyStateContainer
    {
        public Employee Value { get; set; }
        public event Action OnStateChange;
        public void setValue(Employee value)
        {
            this.Value = value;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
