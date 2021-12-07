using System.Collections.Generic;
using System.ComponentModel;

namespace Reminder.DAL
{
    public interface IDatabaseAccess<T>
    {
        BindingList<T> GetAllEntities();
    }
}