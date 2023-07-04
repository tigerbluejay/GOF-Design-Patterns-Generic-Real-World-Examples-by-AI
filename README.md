# GOF Design Patterns
# Generic and Real-World Examples by ChatGPT AI

This Solution is a working compilation of the GOF Design Patterns.
Projects contain anotated generic examples, real world examples and .NET examples or implementations of the patterns.

I asked ChatGPT to rank the patterns in order of complexity for human understanding and it provided the following ranked list, 
which I recommend when reading through and debugging the examples.

- Singleton
- Factory Method
- Observer
- Strategy
- Template Method
- Adapter
- Decorator
- Command
- Proxy
- Iterator
- Composite
- Facade
- State
- Bridge
- Abstract Factory
- Builder
- Prototype
- Mediator
- Visitor
- Chain of Responsibility
- Flyweight
- Memento
- Interpreter

Below each pattern I also transcribe here the most common scenarios where they are used.


## SINGLETON

The Singleton design pattern is used when we need to ensure that only one instance of a class is created throughout the execution of a program. It restricts the instantiation of a class to a single object and provides a global point of access to that object. Here are some common scenarios where the Singleton pattern is applied:

1) Configuration settings: The Singleton pattern is often used to manage global configuration settings. It allows access to these settings from anywhere within the program, ensuring consistency and avoiding the need to pass configuration objects around.

2) Caching: Singletons are commonly employed in caching scenarios where you need to store and retrieve frequently accessed data. The Singleton instance acts as a cache manager, providing a centralized point for data storage and retrieval.

3) Database connections: In applications that require database connectivity, the Singleton pattern can be used to manage database connections. Since opening and closing connections can be resource-intensive, a Singleton instance can handle connection pooling, ensuring that only a limited number of connections are created and shared.

4) Logging: Singleton pattern can be utilized in logging mechanisms where a single logging instance is used throughout the application. It allows multiple components to log information to a single log file or system, providing centralized and consistent logging behavior.

5) Thread pools: When dealing with multi-threaded applications, the Singleton pattern can be used to implement a thread pool. A Singleton instance can manage a pool of threads, ensuring efficient utilization and control over thread creation and termination.

6) Event managers: Singletons are often used as event managers or message brokers. They provide a centralized mechanism for publishing and subscribing to events, allowing components to communicate with each other effectively.

It's important to note that while the Singleton pattern can be useful in certain situations, its use should be carefully considered. Overuse of Singletons can lead to tight coupling and difficulties in testing and maintainability.


## FACTORY METHOD
  
The Factory Method design pattern is used when we want to create objects without specifying their concrete classes directly. It provides an interface for creating objects, but allows subclasses to decide which class to instantiate. Here are some common scenarios where the Factory Method pattern is applied:

1) Object creation with complex logic: When object creation involves complex logic or requires the involvement of multiple classes, the Factory Method pattern can be used. It encapsulates the object creation process in a separate factory class, which can handle the complexity and return the appropriate object.

2) Creating objects based on runtime conditions: In scenarios where the type of object to be created depends on runtime conditions or configuration settings, the Factory Method pattern is helpful. The factory class can examine the runtime parameters and determine the appropriate class to instantiate.

3) Dynamic extension of object creation: The Factory Method pattern allows for dynamic extension of object creation. Subclasses can provide their own implementations of the factory method, allowing for the creation of different types of objects that conform to a common interface or base class.

4) Encapsulating object creation in a single location: The Factory Method pattern provides a centralized location for creating objects. This can help in maintaining consistency and adhering to the principle of separating object creation from usage.

5) Testing and decoupling: By using the Factory Method pattern, object creation can be easily mocked or stubbed during unit testing. This helps in isolating dependencies and simplifying the testing process. Additionally, it reduces coupling between client code and concrete classes, as the client code only needs to know about the factory interface.

6) Dependency injection: The Factory Method pattern can be used as a form of dependency injection. Instead of directly instantiating objects, the factory class can be injected into client code, allowing the client to create objects through the factory's interface. This promotes loose coupling and improves flexibility.

Overall, the Factory Method pattern provides a flexible and extensible way to create objects, allowing for runtime decisions and encapsulation of object creation logic. It is especially useful in scenarios where the specific type of object to be created is not known at compile-time or may vary based on runtime conditions.


## OBSERVER

The Observer design pattern is used when there is a one-to-many relationship between objects, where changes in one object need to be propagated to multiple dependent objects. It allows objects to be loosely coupled, ensuring that changes in one object trigger updates in other objects automatically. Here are some common scenarios where the Observer pattern is applied:

1) Event handling: The Observer pattern is commonly used in event-driven systems where events occur and need to be notified to multiple subscribers. The subject object acts as an event source, while the observer objects subscribe to receive and handle those events.

2) User interface updates: In graphical user interfaces (GUIs), the Observer pattern is often used to update the user interface components based on changes in underlying data. For example, when the data in a model changes, the views that display that data can be automatically updated.

3) Message passing systems: When there is a need to propagate messages or notifications between components or systems, the Observer pattern can be employed. The subject object can act as a message publisher, while the observer objects act as message subscribers.

4) Stock market monitoring: The Observer pattern is suitable for monitoring stock market prices. The subject object can represent the stock exchange or a particular stock, and the observer objects can be various traders or investors who want to be notified of price changes.

5) Publish/subscribe systems: The Observer pattern is a core concept in publish/subscribe systems. Publishers publish messages or events, and subscribers subscribe to receive those messages. The Observer pattern facilitates the decoupling of publishers and subscribers, allowing for dynamic and scalable systems.

6) Distributed systems: In distributed systems where components are spread across different nodes or machines, the Observer pattern can be used to propagate updates or events across the system. Changes in one component can be observed by other components, enabling synchronization and coordination.

The Observer pattern provides a flexible and scalable approach for implementing event-driven systems and managing dependencies between objects. It promotes loose coupling and allows for dynamic registration and removal of observers, making it suitable for a wide range of scenarios where objects need to be notified and updated based on changes in other objects.


## STRATEGY

The Strategy design pattern is used when we want to define a family of algorithms or behaviors and make them interchangeable at runtime. It allows the selection of a specific algorithm or strategy without tightly coupling it to the client code. Here are some common scenarios where the Strategy pattern is applied:

1) Algorithm selection: The Strategy pattern is commonly used when different algorithms or strategies can be applied to solve a problem, and the choice of the algorithm needs to be flexible. It allows the client code to select and switch between different strategies based on runtime conditions or user preferences.

2) Sorting and searching: The Strategy pattern is often employed in sorting and searching scenarios. Different sorting or searching algorithms, such as bubble sort, merge sort, or binary search, can be encapsulated as strategies. The client code can then select the appropriate strategy based on the size of the data or other criteria.

3) File compression: In file compression applications, the Strategy pattern can be used to define different compression algorithms, such as ZIP, GZIP, or RAR. The client code can choose the appropriate strategy based on the file type, compression level, or other factors.

4) Payment processing: The Strategy pattern can be applied in payment processing systems where different payment methods (credit card, PayPal, bank transfer, etc.) need to be supported. Each payment method can be implemented as a strategy, and the client code can select the appropriate strategy based on user preferences or availability.

5) User interface customization: The Strategy pattern is useful in scenarios where the behavior or appearance of a user interface component needs to be customizable. Different strategies can be defined to handle various customization options, and the client code can select the desired strategy to modify the component's behavior or appearance.

6) Game development: In game development, the Strategy pattern can be employed to define different AI strategies for computer-controlled opponents. Each strategy can encapsulate a specific behavior or decision-making approach, allowing dynamic selection of opponents' strategies during gameplay.

The Strategy pattern provides a flexible way to encapsulate and interchange algorithms or behaviors. It promotes code reusability, maintainability, and scalability by separating the implementation details of the strategies from the client code. It is especially useful in situations where multiple variations of an algorithm or behavior need to be supported and selected at runtime.


## TEMPLATE METHOD

The Template Method design pattern is used when we want to define the skeleton of an algorithm in a base class but allow subclasses to provide specific implementations of certain steps. It enables code reuse and promotes consistency across related classes. Here are some common scenarios where the Template Method pattern is applied:

1) Algorithmic frameworks: The Template Method pattern is frequently used in algorithmic frameworks where the overall algorithm's structure remains the same, but specific steps or details may vary. The base class defines the overall algorithm structure, while subclasses provide concrete implementations for the varying steps.

2) Lifecycle hooks: When working with frameworks or libraries that have a lifecycle, the Template Method pattern can be useful. The base class provides hooks, which are methods with empty or default implementations, that allow subclasses to customize or extend the behavior at specific points during the lifecycle.

3) Workflow processing: In workflow or business process management systems, the Template Method pattern can be employed. The base class defines the overall workflow structure, with each step represented as a method. Subclasses can override specific steps to handle variations in processing logic.

4) Code generation: The Template Method pattern can be used in code generation scenarios where a base class represents a generic code structure, and subclasses provide concrete implementations for specific language or platform requirements. The base class can generate common code, while subclasses provide language-specific code.

5) Database access: The Template Method pattern is commonly used in database access frameworks. The base class defines the overall database access flow, including steps like connecting to the database, executing queries, and handling transactions. Subclasses can provide database-specific implementations for these steps.

6) GUI frameworks: The Template Method pattern is applicable in graphical user interface frameworks. The base class can define the overall structure of a GUI component, including methods for rendering, event handling, and layout management. Subclasses can override specific methods to customize the appearance and behavior of the component.

The Template Method pattern allows for reusable and customizable algorithms or processes. It promotes code reuse, reduces duplication, and provides a structured approach to implementing variations of an algorithm or process. By separating the common parts from the variable parts, it improves code organization and maintainability.

  
## ADAPTER

The Adapter design pattern is used when we want to make two incompatible interfaces work together by creating a bridge between them. It allows objects with different interfaces to collaborate and communicate seamlessly. Here are some common scenarios where the Adapter pattern is applied:

1) Integrating legacy code: The Adapter pattern is often used when integrating legacy code or third-party libraries that have incompatible interfaces with the existing codebase. The adapter acts as a wrapper, providing a compatible interface that allows the new code to interact with the legacy code.

2) Reusing existing classes: When existing classes need to be reused in a different context or with different interfaces, the Adapter pattern can be utilized. The adapter wraps the existing class, providing a different interface that matches the requirements of the new context or client code.

3) Supporting multiple interfaces: The Adapter pattern can be employed when an object needs to support multiple interfaces. By creating an adapter for each interface, the object can fulfill the contract of different clients or components without the need to modify its core implementation.

4) Interoperability between components: In distributed systems or component-based architectures, the Adapter pattern can facilitate interoperability between components or services with different communication protocols or data formats. Adapters can be used to convert and map the data between the incompatible interfaces.

5) Simplifying complex interfaces: The Adapter pattern can be used to simplify complex interfaces by creating a streamlined and more intuitive interface for client code. The adapter can hide the complexities and nuances of the underlying system, providing a simplified and easier-to-use interface.

6) Testability and mocking: The Adapter pattern can help in improving testability by allowing the creation of mock adapters. Mock adapters can be used during unit testing to simulate the behavior of external systems or dependencies, enabling isolated and controlled testing of the client code.

The Adapter pattern provides a way to make disparate components or interfaces work together without modifying their existing code. It promotes code reuse, flexibility, and extensibility by allowing objects with different interfaces to collaborate seamlessly. It is especially useful in integration scenarios, where systems or components with incompatible interfaces need to be connected and communicate effectively.


## DECORATOR

The Decorator design pattern is used when we want to add additional behavior or functionality to an object dynamically without affecting its underlying structure. It allows for flexible extension of an object's capabilities at runtime. Here are some common scenarios where the Decorator pattern is applied:

1) Adding functionality to existing classes: The Decorator pattern is often used when we have a class hierarchy and want to add new behaviors or functionalities to specific objects dynamically. Instead of modifying the existing classes directly, we can create decorator classes that wrap the original objects and provide the additional functionality.

2) Customizing object behavior: The Decorator pattern allows for customizing the behavior of an object by adding or modifying specific features. It enables the addition of new functionalities to an object without the need to create multiple subclasses or modify existing code.

3) Extending the functionality of libraries: When working with third-party libraries or frameworks, the Decorator pattern can be used to extend their functionality. Instead of modifying the library's code directly, decorators can be applied to wrap the library's objects and provide additional features or behaviors.

4) Logging and debugging: The Decorator pattern is commonly used for logging or debugging purposes. Decorators can be created to wrap objects and add logging statements, error handling, or performance monitoring code without modifying the original object's implementation.

5) Caching and memoization: Decorators can be employed to add caching or memoization functionality to expensive operations or computations. By wrapping the original object with a caching decorator, the results of previous computations can be stored and retrieved, avoiding redundant calculations.

6) Dynamic configuration or parameterization: The Decorator pattern allows for dynamically configuring or parameterizing objects at runtime. Decorators can be used to wrap objects and modify their behavior based on runtime conditions or configuration settings.

The Decorator pattern provides a flexible and modular approach to extending or modifying the behavior of objects. It promotes code reusability, separation of concerns, and the Open/Closed Principle by allowing new functionalities to be added without modifying existing code. It is especially useful when we have a class hierarchy with multiple variations and want to avoid the explosion of subclasses or the modification of existing classes.

  
## COMMAND

The Command design pattern is used when we want to encapsulate a request as an object, allowing us to parameterize clients with different requests, queue or log requests, and support undo operations. It decouples the sender of a request from the receiver, providing flexibility and extensibility. Here are some common scenarios where the Command pattern is applied:

1) Implementing undo/redo functionality: The Command pattern is often used to implement undo/redo operations in applications. Each command object encapsulates a specific operation, allowing the application to store and manage a history of executed commands and reverse or replay them as needed.

2) Queuing and scheduling tasks: The Command pattern can be used to queue and schedule tasks or operations. Command objects can represent individual tasks, and a command queue can be used to manage the order of execution. This approach provides flexibility in managing asynchronous or delayed tasks.

3) Supporting transactional operations: In systems where transactional integrity is crucial, the Command pattern can be employed. Command objects can encapsulate individual steps of a transaction, allowing the system to execute and commit or roll back the transaction as a whole.

4) Implementing menu or button actions: Graphical user interfaces often utilize the Command pattern to handle menu items, buttons, or other user interface actions. Each command object represents a specific action, and the client code can bind these commands to user interface elements. This allows for easy customization and dynamic behavior modification.

5) Remote method invocation: The Command pattern can be used in distributed systems to implement remote method invocation. Command objects can encapsulate method calls and their parameters, allowing them to be sent across a network and executed on remote systems.

6) Logging and auditing: The Command pattern is useful for implementing logging or auditing functionality. By encapsulating each operation as a command, the application can log or record the executed commands, including details such as timestamp, parameters, and user information.

The Command pattern provides a way to decouple the sender and receiver of a request, allowing for flexible and extensible behavior. It enables the encapsulation of operations as objects, supporting undo, queuing, scheduling, and other functionality. It promotes loose coupling, separation of concerns, and supports the implementation of advanced features like undo/redo, logging, and transaction management.


## PROXY

The Proxy design pattern is used when we want to control access to an object by creating a surrogate or placeholder object. The proxy acts as an intermediary between the client and the real object, allowing for additional functionality to be added or controlling the object's behavior. Here are some common scenarios where the Proxy pattern is applied:

1) Remote object access: The Proxy pattern is often used in distributed systems when accessing remote objects. The proxy acts as a local representative for the remote object, handling the communication and hiding the complexities of network operations.

2) Access control and permissions: Proxies can be used to enforce access control and permissions to objects. The proxy can perform authentication, authorization, or other security checks before allowing the client to access the real object. This ensures controlled and secure access to sensitive resources.

3) Lazy initialization: Proxies can be used for lazy initialization of objects, where the real object is only created or loaded when it is actually needed. The proxy can provide a lightweight representation of the object initially and instantiate the real object on-demand, saving resources and improving performance.

4) Caching: Proxies can be utilized for caching expensive or frequently used results. The proxy can store the cached result and return it directly to the client, bypassing the real object if the result is available. This can significantly improve the performance of operations by reducing redundant computations or data retrieval.

5) Logging and auditing: Proxies can be employed to add logging or auditing functionality to objects. The proxy can intercept method calls and log information such as method name, parameters, timestamps, or other relevant details for monitoring or auditing purposes.

6) Performance optimization: Proxies can be used to optimize the performance of objects by implementing techniques such as lazy loading, result caching, or request batching. The proxy intercepts and manages requests, optimizing the underlying object's behavior to improve efficiency.

The Proxy pattern provides a flexible way to control access to objects and add additional functionality without modifying the underlying object. It promotes separation of concerns, improves security, and enhances performance by implementing smart handling of object access and behavior. It is especially useful in scenarios where objects need to be accessed remotely, controlled, or optimized for better performance.


## ITERATOR

The Iterator design pattern is used when we want to provide a way to access the elements of an aggregate object sequentially without exposing its internal structure. It allows clients to iterate over the elements of a collection or container object in a uniform manner. Here are some common scenarios where the Iterator pattern is applied:

1) Collection traversal: The Iterator pattern is commonly used when we need to traverse and process elements of a collection or container object. It provides a standardized way to iterate over the elements, abstracting away the underlying data structure and allowing the client to focus on the iteration logic.

2) Hiding implementation details: The Iterator pattern is useful for encapsulating the internal structure and implementation of a collection object. By providing an iterator interface, the client code can access the elements without needing to know about the specific data structure or implementation details.

3) Multiple traversal strategies: The Iterator pattern allows the implementation of multiple iterators with different traversal strategies for the same collection object. For example, a collection of objects can have iterators that iterate over the elements in different orders (e.g., forward, backward, sorted).

4) Concurrent access: In concurrent or multi-threaded environments, the Iterator pattern can be used to provide safe and consistent access to shared collections. The iterator can handle thread synchronization and ensure that the elements are accessed in a thread-safe manner.

5) Lazy loading of elements: The Iterator pattern can be employed to implement lazy loading of elements in a collection. Instead of loading all elements upfront, the iterator can load elements on-demand, reducing memory consumption and improving performance when dealing with large collections.

6) Custom iteration logic: The Iterator pattern allows clients to define custom iteration logic by providing their own iterators. Clients can implement iterators that filter, transform, or process the elements in a specific way, giving them fine-grained control over the iteration process.

The Iterator pattern provides a uniform and controlled way to traverse and access elements in a collection or container object. It promotes separation of concerns, encapsulation, and abstraction of data structures. It is particularly useful when dealing with complex data structures or when the internal structure of a collection needs to be hidden or protected.


## COMPOSITE

The Composite design pattern is used when we want to treat individual objects and groups of objects uniformly, forming a hierarchical structure. It allows clients to work with individual objects and compositions of objects in a consistent manner. Here are some common scenarios where the Composite pattern is applied:

1) Representing hierarchical structures: The Composite pattern is particularly useful when dealing with hierarchical structures, such as directory trees, organizational hierarchies, or nested document structures. It allows us to treat both individual elements and compositions of elements uniformly, simplifying the representation and manipulation of the hierarchy.

2) Tree-like data structures: When working with tree-like data structures, the Composite pattern can be employed to provide a common interface for accessing and manipulating the nodes. Each node can be an individual element or a composite node that contains other nodes, forming a recursive structure.

3) Recursive algorithms: The Composite pattern is often used in recursive algorithms that operate on tree-like structures. By defining a common interface for individual elements and compositions, the algorithm can traverse and process the entire structure recursively without needing to distinguish between the two.

4) GUI components: The Composite pattern is applicable in graphical user interface frameworks for creating composite components. Components like panels, containers, or windows can be treated as both individual elements and compositions of child components. This allows for the creation of complex user interfaces by nesting components within each other.

5) Operations on groups of objects: The Composite pattern allows for applying operations uniformly to groups of objects. For example, we can define a method that performs an action on all elements in a composition, regardless of whether they are individual elements or sub-compositions.

6) Undo/redo functionality: The Composite pattern is useful for implementing undo/redo functionality in applications. By representing operations as individual objects and compositions of operations, the application can record and manipulate a history of executed operations and easily undo or redo them as needed.

The Composite pattern provides a way to treat individual objects and compositions of objects uniformly, simplifying the manipulation of hierarchical structures. It promotes code reusability, flexibility, and extensibility by providing a common interface for accessing and manipulating elements. It is especially useful in scenarios involving hierarchical data structures, recursive algorithms, or the need to apply operations uniformly to groups of objects.

