#include "stdafx.h"
#include <iostream>
#include <math.h>

using namespace std;

int width = 100;
int height = 100;
int ballY = 50;
int ballX = 50;
int forceFromX = 1;
int forceFromY = 1;

int Distance(int x1, int y1, int x2, int y2)
{
	int xDelta = x1 - x2;
	int yDelta = y1 - y2;

	return sqrt(xDelta * xDelta + yDelta * yDelta);
}

void UpdatePhysics()
{
	if (ballX > width - 2 || ballY < 0)
	{
		forceFromX -= forceFromX;
	}

	ballX += forceFromX;
	ballY += forceFromY;
}

void DrawFrame() 
{
	for (int y = 0; y < height; y++) 
	{
		for (int x = 0; x < height; x++) 
		{
			if (Distance(x, y * 2, ballX, ballY) < 4) 
			{
				cout << ' ';
			}
			else if (Distance(x, y * 2, ballX, ballY) >= 4) 
			{
				cout << "x";
			}
		}
		cout << endl;
	}
}

int main()
{

	/*cout << "Hello world!" << endl;*/

	while (true) 
	{
		UpdatePhysics();
		DrawFrame();
	}

    return 0;
}

