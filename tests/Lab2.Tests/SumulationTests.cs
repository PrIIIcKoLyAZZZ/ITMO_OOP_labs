using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Repositories;
using Xunit;

namespace Lab2.Tests;

public class SumulationTests
{
    [Fact]
    public static void Try_To_Change_Entity_As_Author_Assert_Succes()
    {
        var labsRepository = new Repository<IEducationalEntities>();
        var maximka = new User(Guid.NewGuid(), new Name("Max"));
        var lab1Id = Guid.NewGuid();
        var factory = new Factory(maximka);
        EntityBuildingResult<ILabwork> result = factory.CreateLabworkBuilder()
            .SetName(new Name("lab-2"))
            .SetDiscription(new EntityContent("123"))
            .SetEvaluationCriteria(new EntityContent("be cool"))
            .SetPoints(new Points(3))
            .SetLabworkID(lab1Id)
            .SetLabworkOriginID(lab1Id)
            .Build();

        ILabwork labwork1;

        if (result is EntityBuildingResult<ILabwork>.Success lab_1)
        {
            labwork1 = lab_1.Entity;
        }
        else
        {
            Assert.Fail();
            return;
        }

        labsRepository.AddEntity(labwork1);

        EntityEditingResult checkEditingResult = labwork1.SetNewName(maximka, new Name("lab-2-edited"));

        Assert.True(checkEditingResult is EntityEditingResult.TheEntityHasBeenChanged);
    }

    [Fact]
    public static void Try_To_Change_Entity_As_Not_Author_Assert_Fall()
    {
        var labsRepository = new Repository<IEducationalEntities>();
        var maximka = new User(Guid.NewGuid(), new Name("Max"));
        var neMaximka = new User(Guid.NewGuid(), new Name("NotMax"));
        var lab1Id = Guid.NewGuid();
        var factory = new Factory(maximka);
        EntityBuildingResult<ILabwork> result = factory.CreateLabworkBuilder()
            .SetName(new Name("lab-2"))
            .SetDiscription(new EntityContent("123"))
            .SetEvaluationCriteria(new EntityContent("be cool"))
            .SetPoints(new Points(3))
            .SetLabworkID(lab1Id)
            .SetLabworkOriginID(lab1Id)
            .Build();

        ILabwork labwork1;

        if (result is EntityBuildingResult<ILabwork>.Success lab1)
        {
            labwork1 = lab1.Entity;
        }
        else
        {
            Assert.Fail();
            return;
        }

        labsRepository.AddEntity(labwork1);

        EntityEditingResult checkEditingResult = labwork1.SetNewName(neMaximka, new Name("lab-2-edited"));

        Assert.True(checkEditingResult is EntityEditingResult.AccessDenied);
    }

    [Fact]
    public static void Try_To_Clone_Entity_End_Check_OriginalID_Assert_Succes()
    {
        var labsRepository = new Repository<IEducationalEntities>();
        var maximka = new User(Guid.NewGuid(), new Name("Max"));
        var lab1Id = Guid.NewGuid();
        var factory = new Factory(maximka);
        EntityBuildingResult<ILabwork> result = factory.CreateLabworkBuilder()
            .SetName(new Name("lab-2"))
            .SetDiscription(new EntityContent("123"))
            .SetEvaluationCriteria(new EntityContent("be cool"))
            .SetPoints(new Points(3))
            .SetLabworkID(lab1Id)
            .SetLabworkOriginID(lab1Id)
            .Build();

        ILabwork labwork1;

        if (result is EntityBuildingResult<ILabwork>.Success lab1)
        {
            labwork1 = lab1.Entity;
        }
        else
        {
            Assert.Fail();
            return;
        }

        labsRepository.AddEntity(labwork1);

        ILabwork labwork1coppy;

        EntityBuildingResult<ILabwork> newResult = labwork1.Direct().Build();

        if (newResult is EntityBuildingResult<ILabwork>.Success lab1coppy)
        {
            labwork1coppy = lab1coppy.Entity;
        }
        else
        {
            Assert.Fail();
            return;
        }

        labsRepository.AddEntity(labwork1coppy);
        Assert.True(labwork1.EntityID == labwork1coppy.OriginEntityID);
    }

    [Fact]
    public static void Try_To_Create_Subject_With_100_points_Assert_Succes()
    {
        var repository = new Repository<IEducationalEntities>();
        var maximka = new User(Guid.NewGuid(), new Name("Max"));
        var subId = Guid.NewGuid();
        var factory = new Factory(maximka);
        List<ILabwork> labList = new()
        {
            new Labwork(
                new Name("123"),
                new EntityContent("123"),
                new EntityContent("123"),
                new Points(3),
                new User(Guid.NewGuid(), new Name("coolboy")),
                Guid.NewGuid(),
                Guid.NewGuid()),
        };

        List<ILecture> lecList = new()
        {
            new Lecture(
                Guid.NewGuid(),
                Guid.NewGuid(),
                new Name("123"),
                new EntityContent("123"),
                new EntityContent("123"),
                new User(Guid.NewGuid(), new Name("CoolBoy"))),
        };

        EntityBuildingResult<ISubject> result = factory.CreateSubjectBuilder()
            .SetSubjectID(subId)
            .SetSubjectOriginID(subId)
            .SetSubjectName(new Name("OOP"))
            .SetLabworksList(labList.AsReadOnly())
            .SetLecturesList(lecList.AsReadOnly())
            .SetMaxPointsForSubject(new Points(100))
            .Build();

        Assert.True(result is EntityBuildingResult<ISubject>.Success);
    }

    [Fact]
    public static void Try_To_Create_Subject_With_10_points_Assert_Fall()
    {
        var repository = new Repository<IEducationalEntities>();
        var maximka = new User(Guid.NewGuid(), new Name("Max"));
        var subId = Guid.NewGuid();
        var factory = new Factory(maximka);
        List<ILabwork> labList = new()
        {
            new Labwork(
                new Name("123"),
                new EntityContent("123"),
                new EntityContent("123"),
                new Points(3),
                new User(Guid.NewGuid(), new Name("coolboy")),
                Guid.NewGuid(),
                Guid.NewGuid()),
        };

        List<ILecture> lecList = new()
        {
            new Lecture(
                Guid.NewGuid(),
                Guid.NewGuid(),
                new Name("123"),
                new EntityContent("123"),
                new EntityContent("123"),
                new User(Guid.NewGuid(), new Name("CoolBoy"))),
        };

        EntityBuildingResult<ISubject> result = factory.CreateSubjectBuilder()
            .SetSubjectID(subId)
            .SetSubjectOriginID(subId)
            .SetSubjectName(new Name("OOP"))
            .SetLabworksList(labList.AsReadOnly())
            .SetLecturesList(lecList.AsReadOnly())
            .SetMaxPointsForSubject(new Points(1))
            .Build();

        Assert.True(result is EntityBuildingResult<ISubject>.Fall);
    }
}