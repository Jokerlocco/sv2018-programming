// Jorge Calzada Asenjo

/*
    Calculate the number of peaks on a roller coaster by knowing that a
    peak is that point on the route that is higher than the immediately
    preceding and immediately following and taking into account that
    the roller coaster is circular.
*/

/*
    Example input
    4
    4 10 3 2
    4
    10 3 2 4
    5
    4 10 10 3 2
    0

    Example output
    1
    1
    0
*/

#include <stdio.h>

int main()
{
    int heightsOnCourse;

    scanf("%d", &heightsOnCourse);

    while (heightsOnCourse != 0) {
        int count = 0;

        int heights[heightsOnCourse];
        int i;

        for (i = 0; i < heightsOnCourse - 1; i++)
            scanf("%d ", &heights[i]);
        scanf("%d", &heights[heightsOnCourse - 1]);

        for (i = 0; i < heightsOnCourse; i++) {
            int previous = (i - 1) == -1 ? heightsOnCourse - 1 : i - 1;
            int posterior = (i + 1) == heightsOnCourse ? 0 : i + 1;

            if (heights[i] > heights[previous] &&
                heights[i] > heights[posterior])
                count++;
        }

        printf("%d\n", count);

        scanf("%d", &heightsOnCourse);
    }

	return 0;
}

