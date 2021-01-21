using System;

namespace Compressor
{
    namespace UserIO
    {
        /**
         * Class to save messages to the list when running unit tests.
         */
        public class TestPrinter : MessagePrinter
        {
            private string[] messages;
            private int pointer;

            /**
             * Constructor.
             */
            public TestPrinter()
            {
                this.messages = new string[1];
                this.messages[0] = string.Empty;
                this.pointer = 0;
            }

            private void doubleSize()
            {
                string[] newList = new string[2 * this.messages.Length];
                for (int i = 0; i < this.pointer; i++)
                {
                    newList[i] = this.messages[i];
                }
                for (int i = this.pointer; i < newList.Length; i++)
                {
                    newList[i] = string.Empty;
                }
                this.messages = newList;
            }

            private void addNew(string message)
            {
                while (this.pointer >= this.messages.Length)
                {
                    doubleSize();
                }
                this.messages[pointer] = this.messages[pointer] + message;
                this.pointer++;
            }

            private void addNewWithoutNewLine(string message)
            {
                while (this.pointer >= this.messages.Length)
                {
                    doubleSize();
                }
                this.messages[pointer] = this.messages[pointer] + message;
            }

            /**
             * Save message without line break.
             * 
             * @param message       Message to save.
             */
            public void print(string message)
            {
                addNewWithoutNewLine(message);
            }

            /**
             * Save message with line break.
             * 
             * @param message       Message to save.
             */
            public void println(string message)
            {
                addNew(message);
            }

            /**
             * Save exception with line break.
             * 
             * @param exception     Exception to save as message
             */
            public void println(Exception exception)
            {
                addNew(exception.Message);
            }

            /**
             * Method to get size of the messages.
             * 
             * @return  Size of the messages
             */
            public int messagesSize()
            {
                if (this.messages.Length > this.pointer && this.messages[this.pointer].Length != 0)
                {
                    return this.pointer + 1;
                }
                return this.pointer;
            }

            /**
             * Method to get message in the index.
             * 
             * @param i     Index
             * @return      Message as String
             */
            public string messageInIndex(int i)
            {
                return this.messages[i];
            }

            /**
             * Method to print message in the index with Console.WriteLine().
             * 
             * @param i     Index
             */
            public void printMessageInIndex(int i)
            {
                Console.WriteLine(this.messages[i]);
            }
        }
    }
}