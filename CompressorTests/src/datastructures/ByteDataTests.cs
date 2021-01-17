using System;
using System.Text;
using Xunit;
using Compressor.DataStructures;

namespace CompressorTests
{
    namespace DataStructuresTests
    {
        public class ByteDataTests : IDisposable
        {
            ByteData byteData;

            ByteData parentTest;
            ByteData leftChildTest;
            ByteData rightChildTest;

            ByteData previousTest;
            ByteData nextTest;

            public ByteDataTests()
            {
                byteData = new ByteData((byte)75);
            }

            public void Dispose()
            {
                //
            }

            [Fact]
            public void afterInitialization()
            {
                try
                {
                    Assert.Equal(75, (int)this.byteData.getNormalChar());
                    Assert.Equal(-1L, this.byteData.getCompressedChar());
                    Assert.Equal(0, (int)this.byteData.getCompressedLength());
                    Assert.Equal(0, this.byteData.getCount());
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    Assert.True(false);
                }
            }

            [Fact]
            public void setAndGetWorks()
            {
                try
                {
                    byteData.setNormalChar((byte)112);
                    byteData.setCompressedChar(11235346L);
                    byteData.setCompressedLength(114);
                    byteData.setCount(114325);

                    byteData.setParent(this.parentTest);
                    byteData.setLeftChild(this.leftChildTest);
                    byteData.setRightChild(this.rightChildTest);

                    byteData.setPrevious(this.previousTest);
                    byteData.setNext(this.nextTest);

                    Assert.Equal(112, (int)this.byteData.getNormalChar());
                    Assert.Equal(11235346L, this.byteData.getCompressedChar());
                    Assert.Equal(114, (int)this.byteData.getCompressedLength());
                    Assert.Equal(114325, this.byteData.getCount());
                    this.byteData.growCount();
                    Assert.Equal(114326, this.byteData.getCount());

                    Assert.Equal(this.parentTest, this.byteData.getParent());
                    Assert.Equal(this.leftChildTest, this.byteData.getLeftChild());
                    Assert.Equal(this.rightChildTest, this.byteData.getRightChild());

                    Assert.Equal(this.previousTest, this.byteData.getPrevious());
                    Assert.Equal(this.nextTest, this.byteData.getNext());
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    Assert.True(false);
                }
            }
        }
    }
}