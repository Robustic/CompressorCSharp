using System;
using Xunit;
using Compressor.DataStructures;

namespace CompressorTests
{
    namespace DataStructuresTests
    {
        public class ByteDataLinkedListTests : IDisposable
        {
            ByteData byteData2;
            ByteData byteData4;
            ByteData byteData0;
            ByteData byteData3;
            ByteData byteData1;

            ByteDataLinkedList byteDataLinkedList;

            public ByteDataLinkedListTests()
            {
                this.byteData2 = new ByteData((byte)2);
                this.byteData2.setCount(2);
                this.byteData4 = new ByteData((byte)4);
                this.byteData4.setCount(4);
                this.byteData0 = new ByteData((byte)10);
                this.byteData3 = new ByteData((byte)3);
                this.byteData3.setCount(3);
                this.byteData1 = new ByteData((byte)1);
                this.byteData1.setCount(1);

                this.byteDataLinkedList = new ByteDataLinkedList();
            }

            public void Dispose()
            {
                //
            }

            [Fact]
            public void afterInitialization()
            {
                byteDataLinkedList.startIteration();
                Assert.Equal(null, byteDataLinkedList.checkObject());
            }

            [Fact]
            public void nextByteDataIsReturnedOk()
            {
                this.byteDataLinkedList.add(this.byteData2);
                byteDataLinkedList.startIteration();
                Assert.Equal(null, byteDataLinkedList.checkObject());
                this.byteDataLinkedList.add(this.byteData4);
                byteDataLinkedList.startIteration();
                Assert.Equal(this.byteDataLinkedList.getFirst(), byteDataLinkedList.checkObject());

                ByteData[] byteDataList = new ByteData[3];
                byteDataList[0] = this.byteData3;
                byteDataList[1] = this.byteData0;
                byteDataList[2] = this.byteData1;
                this.byteDataLinkedList.addArray(byteDataList);
                byteDataLinkedList.startIteration();

                ByteData current = byteDataLinkedList.nextObject();
                Assert.Equal(this.byteData1, current);
                Assert.Equal(byteDataLinkedList.getFirst(), current.getPrevious());
                Assert.Equal(this.byteData2, current.getNext());

                current = byteDataLinkedList.nextObject();
                Assert.Equal(this.byteData2, current);
                Assert.Equal(this.byteData1, current.getPrevious());
                Assert.Equal(this.byteData3, current.getNext());

                current = byteDataLinkedList.nextObject();
                Assert.Equal(this.byteData3, current);
                Assert.Equal(this.byteData2, current.getPrevious());
                Assert.Equal(this.byteData4, current.getNext());

                current = byteDataLinkedList.nextObject();
                Assert.Equal(this.byteData4, current);
                Assert.Equal(this.byteData3, current.getPrevious());
                Assert.Equal(byteDataLinkedList.getLast(), current.getNext());

                current = byteDataLinkedList.nextObject();
                Assert.Equal(null, current);
            }
        }
    }
}