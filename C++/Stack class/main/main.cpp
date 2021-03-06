#include "stdafx.h"
#include <iostream>
#include "Stack.h"

using namespace std;

int main()
{
	/*cout << "Hello world!" << endl;*/

	Stack theStack = Stack();

	int i;
	int j;
	int k;
	int l;

	cout << "Enter your first number here: ";
	cin >> i;
	cout << "Enter your second number here: ";
	cin >> j;
	cout << "Enter your third number here: ";
	cin >> k;
	cout << "Enter your fourth number here: ";
	cin >> l;
	cout << endl;

	theStack.Push(i);
	theStack.Push(j);
	theStack.Push(k);
	theStack.Push(l);

	cout << endl;
	cout << "Number of int's in the stack: " << theStack.Size() << "." << endl;
	cout << endl;

	i = theStack.Pop();
	cout << "Popped this int: " << i << "." << endl;

	j = theStack.Pop();
	cout << "Popped this int: " << j << "." << endl;

	cout << endl;
	cout << "Number of int's in the stack: " << theStack.Size() << "." << endl;
	cout << endl;

	cout << "Resizing stacks" << endl;
	theStack.Resize();
	cout << endl;

	if (theStack.Size() < 4) 
	{
		cout << "The stack is no longer full." << endl;
		cout << endl;
	}

	system("pause");

	return 0;
}

// Defintion: the stack is a last in first out (LIFO) data structure.

