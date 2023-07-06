using System;

// Context class: Document
class Document
{
	private IDocumentState currentState;

	public Document()
	{
		// Set initial state
		currentState = new DraftState();
	}

	public void SetState(IDocumentState state)
	{
		currentState = state;
	}

	public void Edit()
	{
		currentState.Edit(this);
	}

	public void Review()
	{
		currentState.Review(this);
	}

	public void Publish()
	{
		currentState.Publish(this);
	}
}

// State interface: IDocumentState
interface IDocumentState
{
	void Edit(Document document);
	void Review(Document document);
	void Publish(Document document);
}

// Concrete state class: DraftState
class DraftState : IDocumentState
{
	public void Edit(Document document)
	{
		Console.WriteLine("Editing the document.");
		document.SetState(new PendingReviewState());
	}

	public void Review(Document document)
	{
		Console.WriteLine("Cannot review an unedited document.");
	}

	public void Publish(Document document)
	{
		Console.WriteLine("Cannot publish an unedited document.");
	}
}

// Concrete state class: PendingReviewState
class PendingReviewState : IDocumentState
{
	public void Edit(Document document)
	{
		Console.WriteLine("Editing the document.");
		document.SetState(new DraftState());
	}

	public void Review(Document document)
	{
		Console.WriteLine("Reviewing the document.");
		document.SetState(new PublishedState());
	}

	public void Publish(Document document)
	{
		Console.WriteLine("Cannot publish a document pending review.");
	}
}

// Concrete state class: PublishedState
class PublishedState : IDocumentState
{
	public void Edit(Document document)
	{
		Console.WriteLine("Cannot edit a published document.");
	}

	public void Review(Document document)
	{
		Console.WriteLine("Cannot review an already published document.");
	}

	public void Publish(Document document)
	{
		Console.WriteLine("The document is already published.");
	}
}

// Client code
class Program
{
	static void Main(string[] args)
	{
		Document document = new Document();

		document.Edit();
		document.Review();
		document.Publish();
		document.Edit();
		document.Review();
		document.Publish();
	}
}