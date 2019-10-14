using LibrarySystem.UnitTest;
using LibrarySystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Models.Racks;

namespace VenneslaLibraryTeamWork
{
    [TestClass]
    public class Library_Should
    {
        [TestMethod]
        public void Create_CorrectRackNumber()
        {
            var testCh = 65;
            var testRow = 0;
            var testCol = 0;
            var testNumber = 1;

            var letters = new List<RackLetter>();
            letters.Add(new RackLetter { Letter = (char)testCh++ });

            var rack = new Rack
            {
                RackNumber = testNumber,
                Letters = letters,
                Location = new RackLocation()
                {
                    Row = testRow,
                    Col = testCol
                }
            };


            var options = TestUtilities.GetOptions(nameof(Create_CorrectRackNumber));

            using (var actContext = new LibrarySystemContext(options))
            {
                actContext.Racks.Add(rack);
                actContext.SaveChanges();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var createRack = assertContext.Racks.FirstOrDefault(rackFromBD => rackFromBD.RackNumber == testNumber);
                Assert.IsNotNull(createRack);
            }
        }
        [TestMethod]
        public void Create_CorrectRack()
        {
            var testCh = 65;
            var testRow = 0;
            var testCol = 0;
            var testNumber = 1;

            var letters = new List<RackLetter>();
            letters.Add(new RackLetter { Letter = (char)testCh++ });

            var rack = new Rack
            {
                RackNumber = testNumber,
                Letters = letters,
                Location = new RackLocation()
                {
                    Row = testRow,
                    Col = testCol
                }
            };


            var options = TestUtilities.GetOptions(nameof(Create_CorrectRack));

            using (var actContext = new LibrarySystemContext(options))
            {
                actContext.Racks.Add(rack);
                actContext.SaveChanges();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                Assert.AreEqual(1, assertContext.Racks.Count());
            }
        }
        [TestMethod]
        public void Create_CorrectRackLocationCol()
        {
            var testCh = 65;
            var testRow = 0;
            var testCol = 0;
            var testNumber = 1;

            var letters = new List<RackLetter>();
            letters.Add(new RackLetter { Letter = (char)testCh++ });

            var rack = new Rack
            {
                RackNumber = testNumber,
                Letters = letters,
                Location = new RackLocation()
                {
                    Row = testRow,
                    Col = testCol
                }
            };


            var options = TestUtilities.GetOptions(nameof(Create_CorrectRackLocationCol));

            using (var actContext = new LibrarySystemContext(options))
            {
                actContext.Racks.Add(rack);
                actContext.SaveChanges();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var createRack = assertContext.Racks.FirstOrDefault(rackFromBD => rackFromBD.Location.Col == testCol);
                Assert.IsNotNull(createRack);
            }

        }
        [TestMethod]
        public void Create_CorrectRackLocationRow()
        {
            var testCh = 65;
            var testRow = 0;
            var testCol = 0;
            var testNumber = 1;

            var letters = new List<RackLetter>();
            letters.Add(new RackLetter { Letter = (char)testCh++ });

            var rack = new Rack
            {
                RackNumber = testNumber,
                Letters = letters,
                Location = new RackLocation()
                {
                    Row = testRow,
                    Col = testCol
                }
            };


            var options = TestUtilities.GetOptions(nameof(Create_CorrectRackLocationRow));

            using (var actContext = new LibrarySystemContext(options))
            {
                actContext.Racks.Add(rack);
                actContext.SaveChanges();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var createRack = assertContext.Racks.FirstOrDefault(rackFromBD => rackFromBD.Location.Row == testRow);
                Assert.IsNotNull(createRack);
            }

        }
        [TestMethod]
        public void Create_CorrectRackLetter()
        {
            var testCh = 65;
            var testRow = 0;
            var testCol = 0;
            var testNumber = 1;

            var letters = new List<RackLetter>();
            letters.Add(new RackLetter { Letter = (char)testCh++ });

            var rack = new Rack
            {
                RackNumber = testNumber,
                Letters = letters,
                Location = new RackLocation()
                {
                    Row = testRow,
                    Col = testCol
                }
            };


            var options = TestUtilities.GetOptions(nameof(Create_CorrectRackLetter));

            using (var actContext = new LibrarySystemContext(options))
            {
                actContext.Racks.Add(rack);
                actContext.SaveChanges();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                Assert.AreEqual(1, assertContext.RackLetters.Count());
            }
        }      
    }
}