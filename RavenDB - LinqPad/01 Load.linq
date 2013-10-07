<Query Kind="Statements">
  <Reference>C:\Code\Private\aanug_ravendb\src\AANUG_RavenDB\bin\Debug\AANUG_RavenDB.dll</Reference>
  <NuGetReference>RavenDB.Client</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>Raven.Client</Namespace>
  <Namespace>Raven.Client.Document</Namespace>
  <Namespace>Raven.Client.Indexes</Namespace>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.PlatformServices</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
  <Namespace>AANUG_RavenDB</Namespace>
  <Namespace>AANUG_RavenDB.Generators</Namespace>
</Query>

var documentStore = new DocumentStore { Url="http://localhost:8081", DefaultDatabase = "AANUG" };

documentStore.Initialize();

using (var documentSession = documentStore.OpenSession())
{
	var conference = documentSession.Load<Conference>(1);
		
	conference.Dump();
}