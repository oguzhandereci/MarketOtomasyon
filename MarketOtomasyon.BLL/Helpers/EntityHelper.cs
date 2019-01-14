using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketOtomasyon.Helpers
{
    public class EntityHelper
    {
        public void FindError(DbEntityValidationException e)
        {
            foreach (var eve in e.EntityValidationErrors)
            {
                MessageBox.Show($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                foreach (var ve in eve.ValidationErrors)
                {
                    MessageBox.Show($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                }
            }
        }
    }
}
