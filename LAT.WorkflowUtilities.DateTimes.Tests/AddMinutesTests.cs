﻿using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.DateTimes.Tests
{
    [TestClass]
    public class AddMinutesTests
    {
        #region Test Initialization and Cleanup
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext) { }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void ClassCleanup() { }

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void TestMethodInitialize() { }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void TestMethodCleanup() { }
        #endregion

        [TestMethod]
        public void AddMinutes_Add_Plus_One()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "OriginalDate", new DateTime(2014, 7, 3, 8, 48, 0, 0)},
                { "MinutesToAdd", 1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            DateTime expected = new DateTime(2014, 7, 3, 8, 49, 0, 0);

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<AddMinutes>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["UpdatedDate"]);
        }

        [TestMethod]
        public void AddMinutes_Add_Plus_Five()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "OriginalDate", new DateTime(2014, 7, 3, 8, 48, 0, 0)},
                { "MinutesToAdd", 5 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            DateTime expected = new DateTime(2014, 7, 3, 8, 53, 0, 0);

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<AddMinutes>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["UpdatedDate"]);
        }

        [TestMethod]
        public void AddMinutes_Add_Plus_Fifty()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "OriginalDate", new DateTime(2014, 7, 3, 8, 48, 0, 0)},
                { "MinutesToAdd", 50 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            DateTime expected = new DateTime(2014, 7, 3, 9, 38, 0, 0);

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<AddMinutes>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["UpdatedDate"]);
        }

        [TestMethod]
        public void AddMinutes_Add_Minus_One()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "OriginalDate", new DateTime(2014, 7, 3, 8, 48, 0, 0)},
                { "MinutesToAdd", -1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            DateTime expected = new DateTime(2014, 7, 3, 8, 47, 0, 0);

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<AddMinutes>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["UpdatedDate"]);
        }

        [TestMethod]
        public void AddMinutes_Add_Minus_Five()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "OriginalDate", new DateTime(2014, 7, 8, 8, 48, 0, 0)},
                { "MinutesToAdd", -5 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            DateTime expected = new DateTime(2014, 7, 8, 8, 43, 0, 0);

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<AddMinutes>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["UpdatedDate"]);
        }

        [TestMethod]
        public void AddMinutes_Add_Minus_Fifty()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "OriginalDate", new DateTime(2014, 7, 3, 8, 48, 0, 0)},
                { "MinutesToAdd", -50 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            DateTime expected = new DateTime(2014, 7, 3, 7, 58, 0, 0);

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<AddMinutes>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["UpdatedDate"]);
        }
    }
}