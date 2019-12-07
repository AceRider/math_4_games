using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    long SetCellState(long bitboard, int row, int col)
    {
        long newBit = 1L << (row * 8 + col);

        return (bitboard |= newBit);
    }

    bool GetCellState(long bitboard, int row, int col)
    {
        long mask = 1L << (row * 8 + col);

        return ((bitboard & mask) != 0);
    }

    int CellCount(long bitboard)
    {
        int count = 0;
        long bb = bitboard;

        while (bb != 0)
        {
            bb &= bb - 1;
            count++;
        }

        return count;
    }
}
