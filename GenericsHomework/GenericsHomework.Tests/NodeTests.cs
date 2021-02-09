using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void NodeConstructor_DifferentValuesAreCreated()
        {
            // Act
            Node<double> node1 = new Node<double>(42.0);
            Node<int> node2 = new Node<int>(13);
            Node<string> node3 = new Node<string>("Greetings!");
            Node<char> node4 = new Node<char>('x');

            // Assert
            Assert.AreEqual<double>(42.0, node1.Data);
            Assert.AreEqual<int>(13, node2.Data);
            Assert.AreEqual<string>("Greetings!", node3.Data);
            Assert.AreEqual<char>('x', node4.Data);

        }

        [TestMethod]
        public void Node_ToString_ReturnsTheCorrectString()
        {
            // Arrange
            double num = 19.99;
            string str = "Sloppy";

            // Act
            Node<double> node1 = new Node<double>(num);
            Node<string> node2 = new Node<string>(str);

            // Assert
            Assert.AreEqual<string>(num.ToString(), node1.ToString());
            Assert.AreEqual<string>(str.ToString(), node2.ToString());

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Node_ToStringPassesNull_ArgumentNullException()
        { 

            // Act
            Node<string> node1 = new Node<string>(null!);

            node1.ToString();
            
        }

        [TestMethod]
        public void Node_NextConstructor_BuildNextNodeSucceeds()
        {

            // Act
            Node<string> node1 = new Node<string>("Test!");
            Node<string> node1Ref = node1.Next;

            // Assert
            Assert.AreEqual<Node<string>>(node1, node1Ref);

        }

        [TestMethod]
        public void Node_CheckNextValueProperties_NodesAreNotTheSame()
        {

            // Act
            Node<int> node1 = new Node<int>(3);
            Node<int> nodeRef = new Node<int>(9);

            // Assert
            Assert.AreNotEqual<Node<int>>(node1, nodeRef);

        }

        [TestMethod]
        public void Node_InsertNewNode_NewNodeInsertedAndLoops()
        {

            // Act
            Node<string> node1 = new Node<string>("Howdy");
            node1.Insert("Love");

            // Assert
            Assert.AreEqual<string>("Howdy", node1.ToString());
            Assert.AreEqual<string>("Love", node1.Next.ToString());
            Assert.AreEqual<string>("Howdy", node1.Next.Next.ToString());

        }

        [TestMethod]
        public void Node_ClearFunction_AllNodesExceptFirstOneAreCleared()
        {

            // Act
            Node<string> node1 = new Node<string>("Howdy");
            node1.Insert("Love");
            node1.Insert("Hello Gordon!");
            node1.Insert("Soda");
            node1.Insert("There Is Nothing");
            node1.Insert("Kisses");

            node1.Clear();

            // Assert
            Assert.AreEqual<string>("Howdy", node1.Data);
            Assert.AreEqual<string>("Howdy", node1.Next.Data);

        }
    }
}
