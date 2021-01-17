using System;
using System.Text;
using Xunit;
using Compressor.DataStructures;

namespace CompressorTests
{
    namespace DataStructuresTests
    {
        public class ByteListTests
        {
            ByteList list = new ByteList();

            int number = 0;

            [Fact]
            public void increase()
            {
                number = number + 1;
            }

            [Fact]
            public void initializedIsEmpty1()
            {

                // list = new ByteListClass();
                Assert.Equal(0, list.size());
                Assert.Equal(0, number);
                increase();
                Assert.Equal(1, number);

                byte newbyte = 64;
                list.add(newbyte);
            }

            [Fact]
            public void initializedIsEmpty2()
            {

                // list = new ByteListClass();
                Assert.Equal(0, list.size());
                Assert.Equal(0, number);

            }

            [Fact]
            public void newBytesCanBeAdded()
            {
                try
                {
                    this.list.add((byte)'a');
                    this.list.add((byte)'b');
                    this.list.add((byte)'c');
                    Assert.Equal(3, this.list.size());
                    Assert.Equal((byte)'a', this.list.get(0));
                    Assert.Equal((byte)'b', this.list.get(1));
                    Assert.Equal((byte)'c', this.list.get(2));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Assert.True(false);
                }
            }

            [Fact]
            public void negativeIndexNotAllowed()
            {
                try
                {
                    this.list.add((byte)'a');
                    this.list.add((byte)'b');
                    this.list.add((byte)'c');
                    this.list.get(-1);
                    Assert.True(false);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Assert.True(true);
                }
            }

            [Fact]
            public void tooBigIndexNotAllowed()
            {
                try
                {
                    this.list.add((byte)'a');
                    this.list.add((byte)'b');
                    this.list.add((byte)'c');
                    this.list.get(3);
                    Assert.True(false);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Assert.True(true);
                }
            }

            [Fact]
            public void givenByteListIsOk()
            {
                try
                {
                    this.list.add((byte)'a');
                    this.list.add((byte)'b');
                    this.list.add((byte)'c');
                    byte[] returnedList = this.list.getBytesAsArray();
                    Assert.Equal(3, returnedList.Length);
                    Assert.Equal((byte)'a', returnedList[0]);
                    Assert.Equal((byte)'b', returnedList[1]);
                    Assert.Equal((byte)'c', returnedList[2]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Assert.True(false);
                }
            }

            [Fact]
            public void combineBytesOk()
            {
                try
                {
                    byte[] firstBytes = Encoding.ASCII.GetBytes("abc");
                    byte[] secondBytes = Encoding.ASCII.GetBytes("defghi");
                    this.list.combine(firstBytes);
                    Assert.Equal(3, list.size());
                    this.list.combine(secondBytes);
                    Assert.Equal(9, list.size());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Assert.True(false);
                }
            }

            [Fact]
            public void readingByteByByteWorks()
            {
                try
                {
                    byte[] firstBytes = Encoding.ASCII.GetBytes("abc");
                    this.list.combine(firstBytes);
                    this.list.startReading();
                    Assert.Equal((byte)'a', this.list.readNext());
                    Assert.Equal((byte)'b', this.list.readNext());
                    this.list.startReading();
                    Assert.True(this.list.checkNext());
                    Assert.Equal((byte)'a', this.list.readNext());
                    Assert.True(this.list.checkNext());
                    Assert.Equal((byte)'b', this.list.readNext());
                    Assert.True(this.list.checkNext());
                    Assert.Equal((byte)'c', this.list.readNext());
                    Assert.False(this.list.checkNext());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Assert.True(false);
                }
            }

            [Fact]
            public void byteInIndexCanBeSet()
            {
                try
                {
                    byte[] firstBytes = Encoding.ASCII.GetBytes("abc");
                    this.list.combine(firstBytes);
                    Assert.Equal((byte)'b', this.list.get(1));
                    this.list.set(1, (byte)77);
                    Assert.Equal((byte)'M', this.list.get(1));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Assert.True(false);
                }
            }

            [Fact]
            public void tooSmallIndexCauseException()
            {
                try
                {
                    byte[] firstBytes = Encoding.ASCII.GetBytes("abc");
                    this.list.combine(firstBytes);
                    this.list.set(-1, (byte)77);
                }
                catch (Exception exception)
                {
                    Assert.Equal("Index have to be inside list! Index -1 is outside list. List length is 3.", exception.Message);
                }
            }

            [Fact]
            public void tooLargeIndexCauseException()
            {
                try
                {
                    byte[] firstBytes = Encoding.ASCII.GetBytes("abc");
                    this.list.combine(firstBytes);
                    this.list.set(3, (byte)77);
                }
                catch (Exception exception)
                {
                    Assert.Equal("Index have to be inside list! Index 3 is outside list. List length is 3.", exception.Message);
                }
            }

            [Fact]
            public void addingEmptyBytesWorks()
            {
                try
                {
                    byte[] firstBytes = Encoding.ASCII.GetBytes("abc");
                    this.list.combine(firstBytes);
                    Assert.Equal(3, list.size());
                    this.list.addEmpties(2);
                    Assert.Equal(5, list.size());
                    Assert.Equal((byte)'a', this.list.get(0));
                    Assert.Equal((byte)'b', this.list.get(1));
                    Assert.Equal((byte)'c', this.list.get(2));
                    Assert.Equal(0, this.list.get(3));
                    Assert.Equal(0, this.list.get(4));
                }
                catch (Exception exception)
                {
                    Assert.Equal("Index have to be inside list! Index 3 is outside list. List length is 3.", exception.Message);
                }
            }


        }
    }
}