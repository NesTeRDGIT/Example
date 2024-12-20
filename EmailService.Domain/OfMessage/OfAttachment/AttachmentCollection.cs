using System.Collections.ObjectModel;

namespace EmailService.Domain.OfMessage.OfAttachment
{
    /// <summary>
    /// Коллекция вложений
    /// </summary>
    public class AttachmentCollection : ReadOnlyCollection<Attachment>
    {
        public AttachmentCollection(IList<Attachment> list) : base(list)
        {
        }

        /// <summary>
        /// Добавить
        /// </summary>
        public Attachment Add(string filename, byte[] data)
        {
            var attachmentId = new AttachmentId(FindNextId());
            var newItem = new Attachment(attachmentId, filename, data);
            Items.Add(newItem);
            return newItem;
        }

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="item">Удаляемое значение</param>
        public void Remove(Attachment item)
        {
            Items.Remove(item);
        }

        /// <summary>
        /// Очистить
        /// </summary>
        public void Clear()
        {
            Items.Clear();
        }

        /// <summary>
        /// Найти следующий Id
        /// </summary>
        /// <returns>Значение следующего Id</returns>
        private long FindNextId()
        {
            if (Items.Count == 0) return 1;
            return Items.Max(x => x.Id.Value) + 1;
        }

        /// <summary>
        /// Оператор преобразования List в AttachmentCollection
        /// </summary>
        /// <param name="items"></param>
        public static implicit operator AttachmentCollection(List<Attachment> items) => new(items);
    }
}
