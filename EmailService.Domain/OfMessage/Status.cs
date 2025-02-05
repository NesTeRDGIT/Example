﻿using Abstraction.DDD.OfValueObject;

namespace EmailService.Domain.OfMessage
{
    /// <summary>
    /// Статус письма
    /// </summary>
    public class Status : StaticReference<Status, string>
    {
        private Status(string value, string name)
        {
            Value = value;
            Name = name;
        }


        /// <summary>
        /// Новое
        /// </summary>
        public static Status New => new("new", "Новое");

        /// <summary>
        /// Отправлено
        /// </summary>
        public static Status Sent => new("sent", "Отправлено");

        /// <summary>
        /// Ошибка отправки
        /// </summary>
        public static Status Error => new("error", "Ошибка отправки");
    }
}
