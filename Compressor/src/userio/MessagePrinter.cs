using System;

namespace Compressor
{
    namespace UserIO
    {
        /**
         * Interface to handle output messages.
         */
        public interface MessagePrinter
        {

            /**
             * Print message without line break.
             * 
             * @param message       Message to print.
             */
            void print(string message);

            /**
             * Print message with line break.
             * 
             * @param message       Message to print.
             */
            void println(string message);

            /**
             * Print exception with line break.
             * 
             * @param exception     Exception to print as message
             */
            void println(Exception exception);
        }
    }
}