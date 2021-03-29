using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Login
{
    public class Tool
    {
        /// <summary>
        /// Уникальный номер инструмента
        /// </summary>
        public virtual int ID { get; }

        /// <summary>
        /// Владелец инструмента
        /// </summary>
        /// <remarks>
        /// У пользователя может быть много инструментов
        /// У инструмента может быть только один владелец
        /// </remarks>
        public virtual User Owner { get; set; }

        /// <summary>
        /// Описание инструмента
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Количество данного инструмента
        /// </summary>
        public virtual int Kolichestvo { get; set; }

        /// <summary>
        /// Когда был куплен инстрмент
        /// </summary>
        public virtual DateTime Kupleno { get; set; }

        public override string ToString()
        {
            // Из этих полей будет создаваться текстовый вид инструмента (ID и старость в месяцах)
            return $"{ID}, " +
                // Количество дней со дня покупки: Сегодня - Дата покупки, 
                // Количество месяцев с покупки: количество дней со дня покупки поделить на 30
                $"{ (DateTime.Today - Kupleno).Days / 30 }"; 
        }

        /// <summary>
        /// Возвращает все инструменты в базеданных
        /// </summary>
        /// <returns>Список всех инструментов в базе данных</returns>
        public static IList<Tool> GetAll()
        {
            // Select * From Tool
            return DataBase.Session.QueryOver<Tool>().List();
        }
    }

    internal class ToolMap : ClassMap<Tool>
    {
        public ToolMap()
        {
            // ID не вводится вручную, а генерируется
            // Для этого используется .GeneratedBy.Identity()
            Id(x => x.ID).GeneratedBy.Identity();

            // Описание подразумевает много текста, 
            // Поэтому при .Length(int.MaxValue) помощи указывается максимальная длинна строки
            Map(x => x.Description).Length(int.MaxValue);
            Map(x => x.Kupleno);

            // Всего один владелец у каждого инструмента
            References(x => x.Owner);
        }
    }
}
