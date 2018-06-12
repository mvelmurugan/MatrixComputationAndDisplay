using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixComputationAndDisplay;
using System.IO;


namespace MatrixComputationAndDisplay.Test
{

    /// <summary>
    /// This class is used to test all the functionalities which are available in Matrix Populator using dependency injection.
    /// </summary>
    [TestClass]
    public class MatrixTestHarness
    {


        MatrixPopulator matrixPopulator = new MatrixPopulator(new TestDataProvider());
        
        public MatrixTestHarness()
        {
            matrixPopulator.FilePath = @"test1.prn";
        }

        /// <summary>
        /// This method will check if the file exists and return the numbers from the file.
        /// </summary>
        [TestMethod]
        public void Test_ValidFile_ReturnNumbers()
        {            
            var numbers = matrixPopulator.Populate(2, 5,1);            
            Assert.IsNotNull(numbers);
        }
        
        /// <summary>
        /// This method will check and return exception if the file is not found.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Should_ThrowException_When_FileNotFound()
        {
            matrixPopulator.FilePath = @"testnotfound.prn";
            var numbers = matrixPopulator.Populate(4, 300, 6);           
            Assert.Fail("A file not found exception is thrown.");
        }



        /// <summary>
        /// This method will check and return exception if the matrix size is invalid.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_ThrowException_When_ForInvalidSize()
        {
            matrixPopulator.Populate(-1, 10);
            Assert.Fail("An exception is thrown for an invalid Matrix size.");
        }

        /// <summary>
        /// This Method will return the result based on the Matrix size and Upper limit.
        /// </summary>
        [TestMethod]       
        public void Test_Valid_MatrixSize_Returns_Value()
        {
            decimal[,] output = matrixPopulator.Populate(0, 4);
            Assert.AreEqual(1, output.Length);
        }

        /// <summary>
        /// This method will check and return exception if the upper limit is invalid.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_ThrowException_When_ForInvalidUpperLimit()
        {             
            matrixPopulator.Populate(4, 1);
            Assert.Fail("An exception is thrown for an invalid Upper Limit.");
        }

        /// <summary>
        /// This Method will return the result based on the Matrix size and Upper limit.
        /// </summary>
        [TestMethod]        
        public void Test_Valid_UpperLimit_Returns_Value()
        {
            decimal[,] output = matrixPopulator.Populate(2, 4);
            Assert.AreEqual(18, output[1,0]);
        }

        /// <summary>
        /// This method will get the numbers from the test.prn file and return the result in decimal array.
        /// </summary>
        [TestMethod]
        public void Test_Valid_ValidNumbers_FromFile()
        {
           
            FileDataProvider fileDataProvider = new FileDataProvider();
            var numbers = fileDataProvider.GetNumbers(matrixPopulator.FilePath);
            Assert.IsNotNull(numbers);

        }

        /// <summary>
        /// This method will get the numbers from the test.prn file and return the result in decimal array.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Should_ThrowException_When_ForInvalidCharactersInFile()
        {
            matrixPopulator.FilePath = @"invalidtest.prn";
            FileDataProvider fileDataProvider = new FileDataProvider();
            var numbers = fileDataProvider.GetNumbers(matrixPopulator.FilePath);
            Assert.Fail("An exception is thrown for invalid characters found in the test.prm file.");
        }


        /// <summary>
        /// This method will check for invalid precision value.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_ThrowException_When_ForInvalidSizePrecision()
        {
            matrixPopulator.Populate(4, 10,-1);
            Assert.Fail("An exception is thrown for an invalid Precision.");
        }

        /// <summary>
        /// This method will check for Valid precison value and format the numbers accordingly.
        /// </summary>
        [TestMethod]        
        public void Test_Accepts_ValidPrecison()
        {
            decimal[,] output = matrixPopulator.Populate(4, 10, 6);
            Assert.AreEqual(25, output.Length);
        }

        /// <summary>
        /// This method will check and throw an expection if the upper limit is greater than the output Matrix size.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_ThrowException_When_ForLimitValueGreaterThanSize()
        {           
            matrixPopulator.Populate(4, 11);
            Assert.Fail("An exception is thrown for an invalid Limit value.");
        }

        /// <summary>
        /// This method will check  the limit value and output matrix size. Based on these, it will return the result.
        /// </summary>
        [TestMethod]        
        public void Test_Valid_UpperLimit_ToCalulateTheMatrix()
        {
            decimal[,] output = matrixPopulator.Populate(4, 10, 6);
            Assert.AreEqual(25, output.Length);
        }

        /// <summary>
        /// This method will return the result based on the Output Matrix size and Upper limit.
        /// </summary>
        [TestMethod]        
        public void Test_Valid_InValid_MatrixDisplay()
        {
            
            decimal[,] output;
            output = matrixPopulator.Populate(0, 4);
            Assert.AreEqual(1, output.Length);
            output = matrixPopulator.Populate(1, 4);
            Assert.AreEqual(4, output.Length);
            output = matrixPopulator.Populate(2, 5);
            Assert.AreEqual(9, output.Length);
            output = matrixPopulator.Populate(4, 7);
            Assert.AreEqual(25, output.Length);
            output = matrixPopulator.Populate(5, 10);
            Assert.AreNotEqual(25, output.Length); //36
            output = matrixPopulator.Populate(6, 9);
            Assert.AreNotEqual(25, output.Length); //49
            output = matrixPopulator.Populate(3, 6);
            Assert.AreNotEqual(2601, output.Length); //16
            output = matrixPopulator.Populate(9, 10);
            Assert.AreEqual(100, output.Length);

        }

        /// <summary>
        /// This method will fetch the result based on the Matrix size and Upperlimit and display the result in (1,1).
        /// </summary>
        [TestMethod]
        public void Test_Invalid_RowANDColumnValue()
        {            
            decimal[,] output = matrixPopulator.Populate(4, 10);
            Assert.AreNotEqual(0.280218M, output[1, 1]); 

        }

        /// <summary>
        /// This method will fetch the result based on the Matrix size and Upperlimit and display the result in (1,1).
        /// </summary>
        [TestMethod]
        public void Test_Valid_RowANDColumnValue()
        {
            decimal[,] output = matrixPopulator.Populate(4, 10);
            Assert.AreEqual(279.0625m, output[1, 1]);

        }


        /// <summary>
        /// This Method will display the same value in both the columns (0,1) and (1,0)
        /// </summary>
        [TestMethod]
        public void Test_Verify_SameResult_InBothColumns ()
        {            
            decimal[,] output = matrixPopulator.Populate(4, 10);
            Assert.AreEqual(output[0, 1], output[1, 0]);

        }

        /// <summary>
        /// This method will display the result based on the precision value.
        /// </summary>
        [TestMethod]
        public void Test_MatrixValue_ByPrecision()
        {           
            decimal[,] output = matrixPopulator.Populate(4, 10,3);            
            Assert.AreEqual(363.062m, output[0, 0]);

        }


    }
}
