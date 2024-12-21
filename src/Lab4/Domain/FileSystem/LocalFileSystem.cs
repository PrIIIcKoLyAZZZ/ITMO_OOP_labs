using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.FileSystem;

public class LocalFileSystem : IFileSystem
{
    public ExecutionResult MoveFile(string sourcePath, string destinationPath)
    {
        if (File.Exists(sourcePath) is false)
            return new ExecutionResult.FileDoesNotExist();

        if (Directory.Exists(destinationPath) is false)
            return new ExecutionResult.DirectoryDoesNotExist();

        File.Move(sourcePath, destinationPath);

        return new ExecutionResult.Success();
    }

    public ExecutionResult CopyFile(string sourcePath, string destinationPath)
    {
        if (File.Exists(sourcePath) is false)
            return new ExecutionResult.FileDoesNotExist();

        if (Directory.Exists(destinationPath) is false)
            return new ExecutionResult.DirectoryDoesNotExist();

        File.Copy(sourcePath, destinationPath);

        return new ExecutionResult.Success();
    }

    public ExecutionResult DeleteFile(string path)
    {
        if (File.Exists(path) is false)
            return new ExecutionResult.FileDoesNotExist();

        File.Delete(path);

        return new ExecutionResult.Success();
    }

    public ExecutionResult RenameFile(string path, string newName)
    {
        if (File.Exists(path) is false)
            return new ExecutionResult.FileDoesNotExist();

        File.Move(path, newName);

        return new ExecutionResult.Success();
    }

    public ExecutionResult ShowFile(string path)
    {
        if (File.Exists(path) is false)
            return new ExecutionResult.FileDoesNotExist();

        string fileContent = File.ReadAllText(path);

        return new ExecutionResult.FileHasBeenFound(fileContent);
    }

    public IList<string> GetFiles(string path)
    {
        return Directory.GetFiles(path);
    }

    public IList<string> GetDirectories(string path)
    {
        return Directory.GetDirectories(path);
    }

    public Name GetDirectoryName(string path)
    {
        ICollection<string> parsedPath = new StringParser().Parse(path);
        return new Name(parsedPath.ElementAt(parsedPath.Count - 1));
    }

    public string MergePaths(string path, string newPath)
    {
        return path + '\\' + newPath;
    }
}