using System;
using System.Text;
using Xunit;
using Compressor.DataStructures;

namespace CompressorTests
{
    namespace DataStructuresTests
    {
        public class ByteDataArrayTest : IDisposable
        {
            ByteDataArray byteDataArray;
            ByteList readByteListCode;
            ByteList writeByteListCode;

            ByteList readByteListUncode;
            ByteList writeByteListUncode;

            public ByteDataArrayTest()
            {
                this.byteDataArray = new ByteDataArray();
                this.readByteListCode = new ByteList();
                this.writeByteListCode = new ByteList();
                this.readByteListUncode = new ByteList();
                this.writeByteListUncode = new ByteList();

                try
                {
                    string someString = "A_DEAD_DAD_CEDED_A_BAD_BABE_A_BEADED_ABACA_BED";
                    for (int i = 0; i < someString.Length; i++)
                    {
                        this.readByteListCode.add((byte)someString[i]);
                    }
                    this.readByteListCode.add((byte)10);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    Assert.True(false);
                }
            }

            public void Dispose()
            {
                //
            }

            [Fact]
            public void afterInitialization()
            {
                Assert.Equal(256, this.byteDataArray.getByteDataArray().Length);
            }

            [Fact]
            public void countingOfBytesWorks()
            {
                byte[] bytes = new byte[7];
                bytes[0] = (byte)127;
                bytes[1] = (byte)15;
                bytes[2] = (byte)128;
                bytes[3] = (byte)26;
                bytes[4] = (byte)15;
                bytes[5] = (byte)128;
                bytes[6] = (byte)128;

                this.byteDataArray.count(bytes);

                Assert.Equal(3, this.byteDataArray.getByteDataArray()[0].getCount());
                Assert.Equal(0, this.byteDataArray.getByteDataArray()[1].getCount());
                Assert.Equal(2, this.byteDataArray.getByteDataArray()[143].getCount());
                Assert.Equal(1, this.byteDataArray.getByteDataArray()[154].getCount());
                Assert.Equal(1, this.byteDataArray.getByteDataArray()[255].getCount());
            }

            [Fact]
            public void codingOfBytesWorks()
            {
                try
                {
                    this.byteDataArray.count(this.readByteListCode.getBytesAsArray());
                    this.byteDataArray.createLinkedList();
                    this.byteDataArray.createBinaryTreeFromLinkedList();
                    this.byteDataArray.compress(this.readByteListCode, this.writeByteListCode);
                    byte[] bytes = this.writeByteListCode.getBytesAsArray();

                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[0]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[1]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[2]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[3]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[4]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[5]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[6]);
                    Assert.Equal(Encoding.ASCII.GetBytes("01111010")[0], bytes[7]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000110")[0], bytes[8]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[9]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[10]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[11]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[12]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[13]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[14]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[15]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00011100")[0], bytes[16]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000101")[0], bytes[17]);
                    Assert.Equal((byte)10, bytes[18]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[19]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[20]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[21]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[22]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[23]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[24]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[25]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000010")[0], bytes[26]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000010")[0], bytes[27]);
                    Assert.Equal((byte)65, bytes[28]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[29]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[30]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[31]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[32]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[33]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[34]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[35]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00001111")[0], bytes[36]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000100")[0], bytes[37]);
                    Assert.Equal((byte)66, bytes[38]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[39]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[40]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[41]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[42]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[43]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[44]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[45]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00011101")[0], bytes[46]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000101")[0], bytes[47]);
                    Assert.Equal((byte)67, bytes[48]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[49]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[50]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[51]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[52]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[53]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[54]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[55]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[56]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000010")[0], bytes[57]);
                    Assert.Equal((byte)68, bytes[58]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[59]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[60]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[61]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[62]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[63]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[64]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[65]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000110")[0], bytes[66]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000011")[0], bytes[67]);
                    Assert.Equal((byte)69, bytes[68]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[69]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[70]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[71]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[72]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[73]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[74]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[75]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000001")[0], bytes[76]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000010")[0], bytes[77]);
                    Assert.Equal((byte)95, bytes[78]);

                    Assert.Equal(Encoding.ASCII.GetBytes("10010011")[0], bytes[79]);
                    Assert.Equal(Encoding.ASCII.GetBytes("01000010")[0], bytes[80]);
                    Assert.Equal(Encoding.ASCII.GetBytes("01000011")[0], bytes[81]);
                    Assert.Equal(Encoding.ASCII.GetBytes("11011100")[0], bytes[82]);
                    Assert.Equal(Encoding.ASCII.GetBytes("01100001")[0], bytes[83]);

                    Assert.Equal(Encoding.ASCII.GetBytes("10011111")[0], bytes[84]);
                    Assert.Equal(Encoding.ASCII.GetBytes("10000111")[0], bytes[85]);
                    Assert.Equal(Encoding.ASCII.GetBytes("11101111")[0], bytes[86]);
                    Assert.Equal(Encoding.ASCII.GetBytes("11001100")[0], bytes[87]);
                    Assert.Equal(Encoding.ASCII.GetBytes("11111110")[0], bytes[88]);

                    Assert.Equal(Encoding.ASCII.GetBytes("10001100")[0], bytes[89]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00110111")[0], bytes[90]);
                    Assert.Equal(Encoding.ASCII.GetBytes("11011101")[0], bytes[91]);
                    Assert.Equal(Encoding.ASCII.GetBytes("10011111")[0], bytes[92]);
                    Assert.Equal(Encoding.ASCII.GetBytes("11000111")[0], bytes[93]);
                    Assert.Equal(Encoding.ASCII.GetBytes("00000000")[0], bytes[94]);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    Assert.True(false);
                }
            }

            [Fact]
            public void uncodingWorks()
            {
                try
                {
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("01111010")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000110")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00011100")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000101")[0]);
                    this.readByteListUncode.add((byte)10);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000010")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000010")[0]);
                    this.readByteListUncode.add((byte)65);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00001111")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000100")[0]);
                    this.readByteListUncode.add((byte)66);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00011101")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000101")[0]);
                    this.readByteListUncode.add((byte)67);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000010")[0]);
                    this.readByteListUncode.add((byte)68);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000110")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000011")[0]);
                    this.readByteListUncode.add((byte)69);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000001")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000010")[0]);
                    this.readByteListUncode.add((byte)95);

                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("10010011")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("01000010")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("01000011")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("11011100")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("01100001")[0]);

                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("10011111")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("10000111")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("11101111")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("11001100")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("11111110")[0]);

                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("10001100")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00110111")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("11011101")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("10011111")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("11000111")[0]);
                    this.readByteListUncode.add(Encoding.ASCII.GetBytes("00000000")[0]);

                    this.byteDataArray.readHeader(this.readByteListUncode);
                    this.byteDataArray.createBinaryTreeFromBinaryCodedCodes();
                    this.byteDataArray.uncompress(this.readByteListUncode, this.writeByteListUncode);

                    Assert.Equal((byte)10, this.writeByteListUncode.get(this.writeByteListUncode.size() - 1));

                    string uncoded = "";
                    for (int i = 0; i < this.writeByteListUncode.size() - 1; i++)
                    {
                        uncoded += (char)this.writeByteListUncode.get(i);
                    }
                    string someString = "A_DEAD_DAD_CEDED_A_BAD_BABE_A_BEADED_ABACA_BED";

                    Assert.Equal(someString, uncoded);
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