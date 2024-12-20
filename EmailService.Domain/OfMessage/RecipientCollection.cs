using System.Collections.ObjectModel;

namespace EmailService.Domain.OfMessage
{
    /// <summary>
    /// Коллекция получателей
    /// </summary>
    public class RecipientCollection : ReadOnlyCollection<Recipient>
    {
        public RecipientCollection(IList<Recipient> list) : base(list)
        {
        }

        /// <summary>
        /// Добавить
        /// </summary>
        public void Add(Recipient item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
        }

        /// <summary>
        /// Добавить
        /// </summary>
        public void AddRange(IEnumerable<Recipient> items)
        {
            foreach (var recipient in items)
            {
                Add(recipient);
            }
        }

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="item">Удаляемое значение</param>
        public void Remove(Recipient item)
        {
            if (Items.Count == 1)
            {
                throw new InvalidOperationException("Невозможно удалить последнего получателя, т.к. список получателей не может быть пуст");
            }
            Items.Remove(item);
        }

        /// <summary>
        /// Заменить
        /// </summary>
        public void Replace(IList<Recipient> items)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Список получателей не может быть пуст");
            }
            Items.Clear();
            AddRange(items);
        }

        /// <summary>
        /// Оператор преобразования List в RecipientCollection
        /// </summary>
        /// <param name="items"></param>
        public static implicit operator RecipientCollection(List<Recipient> items) => new(items);
    }
}
