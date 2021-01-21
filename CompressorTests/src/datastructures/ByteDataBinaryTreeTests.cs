using System;
using System.Text;
using Xunit;
using Compressor.DataStructures;

namespace CompressorTests
{
    namespace DataStructuresTests
    {
        public class ByteDataBinaryTreeTest : IDisposable
        {
            ByteDataBinaryTree byteDataBinaryTree;
            ByteDataLinkedList byteDataLinkedList;

            ByteData byteData2 = new ByteData((byte)2);
            ByteData byteData4 = new ByteData((byte)4);
            ByteData byteData3 = new ByteData((byte)3);
            ByteData byteData1 = new ByteData((byte)1);

            ByteData[] byteDatas;

            public ByteDataBinaryTreeTest()
            {
                byteData2.setCount(2);
                byteData4.setCount(4);
                byteData3.setCount(3);
                byteData1.setCount(1);
                byteDatas = new ByteData[4];
                byteDatas[1] = byteData2;
                byteDatas[3] = byteData4;
                byteDatas[2] = byteData3;
                byteDatas[0] = byteData1;

                this.byteDataLinkedList = new ByteDataLinkedList();
                this.byteDataLinkedList.addArray(byteDatas);

                this.byteDataBinaryTree = new ByteDataBinaryTree();
            }

            public void Dispose()
            {
                //
            }

            [Fact]
            public void afterInitialization()
            {
                Assert.Equal(null, this.byteDataBinaryTree.getRoot());
            }

            [Fact]
            public void binaryTreeGenerationFromTheLinkedListWorks()
            {
                Assert.Equal(null, this.byteDataBinaryTree.getRoot());
                this.byteDataBinaryTree.createBinaryTreeFromLinkedList(this.byteDataLinkedList);
                ByteData root = this.byteDataBinaryTree.getRoot();
                Assert.True(root != null);
                Assert.Equal(10, root.getCount());
                Assert.Equal(byteData4, root.getLeftChild());
                Assert.Equal(root, root.getLeftChild().getParent());
                Assert.Equal(6, root.getRightChild().getCount());
                Assert.Equal(root, root.getRightChild().getParent());
                Assert.Equal(byteData3, root.getRightChild().getLeftChild());
                Assert.Equal(3, root.getRightChild().getRightChild().getCount());
                Assert.Equal(byteData1, root.getRightChild().getRightChild().getLeftChild());
                Assert.Equal(byteData2, root.getRightChild().getRightChild().getRightChild());
                Assert.Equal(root, root.getRightChild().getRightChild().getRightChild().getParent().getParent().getParent());
            }

            [Fact]
            public void compressionCodeGenerationWorks()
            {
                this.byteDataBinaryTree.createBinaryTreeFromLinkedList(this.byteDataLinkedList);
                this.byteDataBinaryTree.saveCodesForTree();

                ByteData root = this.byteDataBinaryTree.getRoot();
                Assert.Equal(0L, root.getLeftChild().getCompressedChar());
                Assert.Equal(1, (int)root.getLeftChild().getCompressedLength());
                Assert.Equal(2L, root.getRightChild().getLeftChild().getCompressedChar());
                Assert.Equal(2, (int)root.getRightChild().getLeftChild().getCompressedLength());
                Assert.Equal(6L, root.getRightChild().getRightChild().getLeftChild().getCompressedChar());
                Assert.Equal(3, (int)root.getRightChild().getRightChild().getLeftChild().getCompressedLength());
                Assert.Equal(7L, root.getRightChild().getRightChild().getRightChild().getCompressedChar());
                Assert.Equal(3, (int)root.getRightChild().getRightChild().getRightChild().getCompressedLength());
            }

            [Fact]
            public void binaryTreeGenerationFromTheBinaryCodedCodesWorks()
            {
                Assert.Equal(null, this.byteDataBinaryTree.getRoot());
                byteData2.setCompressedChar(7L);
                byteData2.setCompressedLength(3);
                byteData4.setCompressedChar(0L);
                byteData4.setCompressedLength(1);
                byteData3.setCompressedChar(2L);
                byteData3.setCompressedLength(2);
                byteData1.setCompressedChar(6L);
                byteData1.setCompressedLength(3);

                ByteData[] byteDatas256 = new ByteData[256];
                for (int i = 0; i < 256; i++)
                {
                    byteDatas256[i] = new ByteData((byte)(i - 128));
                }
                byteDatas256[1] = byteData2;
                byteDatas256[3] = byteData4;
                byteDatas256[2] = byteData3;
                byteDatas256[0] = byteData1;

                this.byteDataBinaryTree.createBinaryTreeFromBinaryCodedCodes(byteDatas256);

                ByteData root = this.byteDataBinaryTree.getRoot();
                Assert.True(root != null);
                Assert.Equal(byteData4, root.getLeftChild());
                Assert.Equal(root, root.getLeftChild().getParent());
                Assert.Equal(root, root.getRightChild().getParent());
                Assert.Equal(byteData3, root.getRightChild().getLeftChild());
                Assert.Equal(byteData1, root.getRightChild().getRightChild().getLeftChild());
                Assert.Equal(byteData2, root.getRightChild().getRightChild().getRightChild());
                Assert.Equal(root, root.getRightChild().getRightChild().getRightChild().getParent().getParent().getParent());
            }
        }
    }
}