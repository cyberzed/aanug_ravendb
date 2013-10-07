<Query Kind="Statements">
  <Reference>C:\Code\Private\aanug_ravendb\src\AANUG_RavenDB\bin\Debug\AANUG_RavenDB.dll</Reference>
  <NuGetReference>RavenDB.Client</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>Raven.Client</Namespace>
  <Namespace>Raven.Client.Document</Namespace>
  <Namespace>Raven.Client.Indexes</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.PlatformServices</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
  <Namespace>AANUG_RavenDB</Namespace>
  <Namespace>AANUG_RavenDB.Generators</Namespace>
  <Namespace>AANUG_RavenDB.Indexes</Namespace>
</Query>

var documentStore = new DocumentStore { Url="http://localhost:8081", DefaultDatabase = "AANUG" };

documentStore.Initialize();

IndexCreation.CreateIndexes( typeof(Speaker).Assembly, documentStore );

using (var documentSession = documentStore.OpenSession())
{
	var conference = documentSession.Query<Conference>().First();
	
	conference.Dump();
	
	var sessionSlot = conference.SessionSlots.First();
	
	var session = (from s in documentSession.Query<Session>() select s).First();
	
	session.Dump();
	
	conference.AddSession(sessionSlot,session);
	
	conference.Dump();
	
	documentSession.Store(conference);
	documentSession.SaveChanges();
}
