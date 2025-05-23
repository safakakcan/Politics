using System.Collections.Generic;

namespace Politics.Scripts.Models;

public class Character
{
    public uint Id { get; set; }
    public string Name { get; set; }

    public Dictionary<uint, Node> Cortex { get; set; } = new()
    {
        {
            1, new Concept(1, "Özgürlük", 0.6f, new()
            {
                {
                    2, 0.4f
                },
                {
                    3, -0.5f
                },
                {
                    8, -0.5f
                },
            })
        },
        {
            2, new Concept(2, "Mutluluk", 0.7f, new()
            {
                {
                    2, 0.0f
                }
            })
        },
        {
            3, new Concept(3, "Baskıcılık", 0.1f, new()
            {
                {
                    5, 0.6f
                },
                {
                    2, -0.4f
                },
            })
        },
        {
            4, new Concept(4, "Güvenlik", 0.3f, new()
            {
                {
                    3, 0.5f
                }
            })
        },
        {
            5, new Concept(5, "Otorite", 0.1f, new()
            {
                {
                    6, -0.9f
                }
            })
        },
        {
            6, new Concept(6, "İsyan", -0.2f, new()
            {
                {
                    5, -0.6f
                },
                {
                    7, 0.6f
                },
            })
        },
        {
            7, new Concept(7, "Umut", 0.5f, new()
            {
                {
                    6, 0.4f
                }
            })
        },
        {
            8, new Concept(8, "Öfke", 0.1f, new()
            {
                {
                    6, 0.6f
                }
            })
        },
    };
}
