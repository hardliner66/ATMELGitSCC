/*
This code is derived from jgit (http://eclipse.org/jgit).
Copyright owners are documented in jgit's IP log.

This program and the accompanying materials are made available
under the terms of the Eclipse Distribution License v1.0 which
accompanies this distribution, is reproduced below, and is
available at http://www.eclipse.org/org/documents/edl-v10.php

All rights reserved.

Redistribution and use in source and binary forms, with or
without modification, are permitted provided that the following
conditions are met:

- Redistributions of source code must retain the above copyright
  notice, this list of conditions and the following disclaimer.

- Redistributions in binary form must reproduce the above
  copyright notice, this list of conditions and the following
  disclaimer in the documentation and/or other materials provided
  with the distribution.

- Neither the name of the Eclipse Foundation, Inc. nor the
  names of its contributors may be used to endorse or promote
  products derived from this software without specific prior
  written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using NGit.Diff;
using Sharpen;

namespace NGit.Diff
{
	[NUnit.Framework.TestFixture]
	public class EditListTest
	{
		[NUnit.Framework.Test]
		public virtual void TestEmpty()
		{
			EditList l = new EditList();
			NUnit.Framework.Assert.AreEqual(0, l.Count);
			NUnit.Framework.Assert.IsTrue(l.IsEmpty());
//			NUnit.Framework.Assert.AreEqual("EditList[]", l.ToString());
			NUnit.Framework.Assert.IsTrue(l.Equals(l));
			NUnit.Framework.Assert.IsTrue(l.Equals(new EditList()));
			NUnit.Framework.Assert.IsFalse(l.Equals(string.Empty));
			NUnit.Framework.Assert.AreEqual(l.GetHashCode(), new EditList().GetHashCode());
		}

		[NUnit.Framework.Test]
		public virtual void TestAddOne()
		{
			Edit e = new Edit(1, 2, 1, 1);
			EditList l = new EditList();
			l.AddItem(e);
			NUnit.Framework.Assert.AreEqual(1, l.Count);
			NUnit.Framework.Assert.IsFalse(l.IsEmpty());
			NUnit.Framework.Assert.AreSame(e, l[0]);
			NUnit.Framework.Assert.AreSame(e, l.Iterator().Next());
			NUnit.Framework.Assert.IsTrue(l.Equals(l));
			NUnit.Framework.Assert.IsFalse(l.Equals(new EditList()));
			EditList l2 = new EditList();
			l2.AddItem(e);
			NUnit.Framework.Assert.IsTrue(l.Equals(l2));
			NUnit.Framework.Assert.IsTrue(l2.Equals(l));
			NUnit.Framework.Assert.AreEqual(l.GetHashCode(), l2.GetHashCode());
		}

		[NUnit.Framework.Test]
		public virtual void TestAddTwo()
		{
			Edit e1 = new Edit(1, 2, 1, 1);
			Edit e2 = new Edit(8, 8, 8, 12);
			EditList l = new EditList();
			l.AddItem(e1);
			l.AddItem(e2);
			NUnit.Framework.Assert.AreEqual(2, l.Count);
			NUnit.Framework.Assert.AreSame(e1, l[0]);
			NUnit.Framework.Assert.AreSame(e2, l[1]);
			Iterator<Edit> i = l.Iterator();
			NUnit.Framework.Assert.AreSame(e1, i.Next());
			NUnit.Framework.Assert.AreSame(e2, i.Next());
			NUnit.Framework.Assert.IsTrue(l.Equals(l));
			NUnit.Framework.Assert.IsFalse(l.Equals(new EditList()));
			EditList l2 = new EditList();
			l2.AddItem(e1);
			l2.AddItem(e2);
			NUnit.Framework.Assert.IsTrue(l.Equals(l2));
			NUnit.Framework.Assert.IsTrue(l2.Equals(l));
			NUnit.Framework.Assert.AreEqual(l.GetHashCode(), l2.GetHashCode());
		}

		[NUnit.Framework.Test]
		public virtual void TestSet()
		{
			Edit e1 = new Edit(1, 2, 1, 1);
			Edit e2 = new Edit(3, 4, 3, 3);
			EditList l = new EditList();
			l.AddItem(e1);
			NUnit.Framework.Assert.AreSame(e1, l[0]);
			NUnit.Framework.Assert.AreSame(e1, l.Set(0, e2));
			NUnit.Framework.Assert.AreSame(e2, l[0]);
		}

		[NUnit.Framework.Test]
		public virtual void TestRemove()
		{
			Edit e1 = new Edit(1, 2, 1, 1);
			Edit e2 = new Edit(8, 8, 8, 12);
			EditList l = new EditList();
			l.AddItem(e1);
			l.AddItem(e2);
			l.Remove(e1);
			NUnit.Framework.Assert.AreEqual(1, l.Count);
			NUnit.Framework.Assert.AreSame(e2, l[0]);
		}
	}
}
