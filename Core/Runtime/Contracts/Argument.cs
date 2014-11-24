using System;

// https://docs.eiffel.com/book/method/et-design-contract-tm-assertions-and-exceptions
namespace PayMe.Runtime.Contracts
{
    public static class Argument
    {
        /// <summary>
        /// Precondition that argument value is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException">when precondition has not been met</exception>
        public static void RequireNotNull<T>(T value, string name)
            where T : class
        {
            if (value == null)
                throw new ArgumentNullException(name);
        }

        /// <summary>
        /// Precondition that argument value is not null or empty.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException">when precondition has not been met</exception>
        public static void RequireNotEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(string.Format("{0} is null or empty", name));
        }

        /// <summary>
        /// Postcondition that argument value is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException">when postcondition has not been met</exception>
        public static void EnsureNotNull<T>(T value, string name)
            where T : class
        {
            if (value == null)
                throw new ArgumentNullException(name);
        }

        /// <summary>
        /// Postcondition that argument value is not null or empty.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException">when postcondition has not been met</exception>
        public static void EnsureNotEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(string.Format("{0} is null or empty", name));
        }
    }
}
