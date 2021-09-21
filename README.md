# Nuka.SDK.SpecificationPattern

Specification Pattern For .Net Core

<领域驱动设计精简版>：
>  规约是用来测试一个对象是否满足特定条件的。
>  领域层包含了应用到实体和值对象上的业务规则。那些规则通常与它们要应用到的对象合成一体。在这些规则中，某些只是用来回答“是”和“否”的一组问题的，某些规则可以被表现成一系列操作布尔值的逻辑上的操作，最终结果也是一个布尔值。一个这样的案例是在一个客户对象上执行测试，看它是否符合特定的信用条件。这个规则可以被表现成一个方法，起名叫 isEligible（），并且可以附加到客户对象上。但这个规则不是严格基于客户的数据进行操作的一个简单的方法。评估规则涉及到验证客户的信用，检查他过去是否支付过他的债务，检查他是否具有足够的余额等。这样的业务规则可能非常的大，非常复杂，让对象的功能肿胀，不再满足其原始的目的。在这种情况下我们可能会试图将整个规则移动到应用层，因为它看上去已经超越了领域层了。实际上，到了重构的时候了。
>  规则应该被封装到一个负责它的对象中，这将成为客户的规约，并且被保留在领域层中。新的对象将包含一系列布尔方法，这些方法用来测试一个客户对象是否符合某种信用。每一个方法担负了一个小的测试的功能，所有的方法可以通过组合对某个原始问题给出答案。如果业务规则不能被包含到一个规约对象中，对应的代码会遍布到无数的对象中，让它不再一致。
>  规约用来测试对象是否满足某种需要，或者他们是否已经为某种目的准备完毕。它也可以被用来从一个集合中筛选一个特定的对象，或者作为某个对象的创建条件。
>  通常情况下，一个单个的规约负责检查是否满足一个简单的规则，若干个这样的规约组合在一起表现一个复杂的规约。
>  测试简单的规则变得非常简单，只需阅读这段代码，这段代码很明显地告诉我们一个客户是否符合偿还条件的真正含义。

References: 
[SPECIFICATIONS, EXPRESSION TREES, AND NHIBERNATE](https://davefancher.com/2012/07/03/specifications-expression-trees-and-nhibernate/)
