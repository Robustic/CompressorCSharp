using System;
using Xunit;
using Compressor.DataStructures.ByteList;

namespace CompressorTests
{
    namespace DataStructuresTests
    {
        namespace ByteListTests
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
            }
        }
    }
}