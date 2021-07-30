using System;
using System.Collections.Generic;

namespace Composite
{
    public class FileStructureProgram
    {
        public FileStructureProgram()
        {
            FileStructure subFolder2 = new Folder("SubFolder2");
            FileStructure file2 = new File("File2");
            FileStructure file2a = new File("File2a");
            FileStructure subFolder1 = new Folder("SubFolder1");
            FileStructure file1 = new File("File1");
            FileStructure subFolder11 = new Folder("SubFolder11");
            FileStructure file11 = new File("File11");
            FileStructure file11a = new File("File11a");
            FileStructure rootFolder = new Folder("Root");
            FileStructure rootFile1 = new File("RootFile1");
            FileStructure rootFile2 = new File("RootFile2");
            FileStructure rootFile3 = new File("RootFile3");

            subFolder2.Add(file2);
            subFolder2.Add(file2a);
            subFolder1.Add(file1);
            subFolder1.Add(subFolder11);
            subFolder11.Add(file11);
            subFolder11.Add(file11a);
            rootFolder.Add(rootFile1);
            rootFolder.Add(rootFile2);
            rootFolder.Add(rootFile3);
            rootFolder.Add(subFolder1);
            rootFolder.Add(subFolder2);

            rootFolder.Print();
        }
    }

    //Component
    public abstract class FileStructure
    {
        public string Name { get; set; }

        public virtual void Add(FileStructure fileStructure)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(FileStructure fileStructure)
        {
            throw new NotImplementedException();
        }

        public virtual void Print()
        {
            throw new NotImplementedException();
        }
    }

    //Composite
    public class Folder : FileStructure
    {
        List<FileStructure> _fileStructureList = new List<FileStructure>();

        public Folder(string name)
        {
            Name = name;
        }

        public override void Add(FileStructure fileStructure)
        {
            _fileStructureList.Add(fileStructure);
        }

        public override void Remove(FileStructure fileStructure)
        {
            _fileStructureList.Remove(fileStructure);
        }

        public override void Print()
        {
            Console.WriteLine($"####{Name}####");
            foreach (var fileStructure in _fileStructureList)
            {
                fileStructure.Print();
            }
        }
    }

    //Leaf
    public class File : FileStructure
    {
        public File(string name)
        {
            Name = name;
        }

        public override void Print()
        {
            Console.WriteLine($"-{Name}");
        }
    }
}