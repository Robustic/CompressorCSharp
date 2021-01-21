using System;

namespace Compressor
{
    namespace UserIO
    {
        /**
         * Class to print messages with System.out.print().
         */
        public class ProductionPrinter : MessagePrinter
        {

            /**
             * Print message without line break.
             * 
             * @param message       Message to print.
             */
            public void print(string message)
            {
                Console.WriteLine(message);
            }

            /**
             * Print message with line break.
             * 
             * @param message       Message to print.
             */
            public void println(string message)
            {
                Console.WriteLine(message);
            }

            /**
             * Print exception with line break.
             * 
             * @param exception     Exception to print as message
             */
            public void println(Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}