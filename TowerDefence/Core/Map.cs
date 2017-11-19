using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TowerDefence.Core {
    public class Map {
        public List<Road> Roads { get; set; }

        public List<Junction> Junctions { get; set; }

        public PointF Start { get; set; }

        public PointF End { get; set; }

        public float RoadThickness { get; set; }

        public Direction EndDirection { get; set; }

        public Map() {
            Roads = new List<Road>();
            Junctions = new List<Junction>();
        }

        public bool EndReached(PointF center) {
            switch (EndDirection) {
                case Direction.Right:
                    return center.X > End.X;
                case Direction.Left:
                    return center.X < End.X;
                case Direction.Up:
                    return center.Y < End.Y;
                case Direction.Down:
                    return center.Y > End.Y;
            }

            return true;
        }

        public void AddRoad(float distance, Direction direction) {
            if (Roads.Count == 0) {
                if (direction == Direction.Right)
                    Roads.Add(new Road(Direction.Right) {
                        Left = Start.X,
                        Top = Start.Y,
                        Distance = distance,
                        Thickness = RoadThickness
                    });
                else if (direction == Direction.Left)
                    Roads.Add(new Road(Direction.Left) {
                        Left = Start.X - distance,
                        Top = Start.Y,
                        Distance = distance,
                        Thickness = RoadThickness
                    });
                else if (direction == Direction.Down)
                    Roads.Add(new Road(Direction.Down) {
                        Left = Start.X,
                        Top = Start.Y,
                        Distance = distance,
                        Thickness = RoadThickness
                    });
                else if (direction == Direction.Up)
                    Roads.Add(new Road(Direction.Up) {
                        Left = Start.X,
                        Top = Start.Y - distance,
                        Distance = distance,
                        Thickness = RoadThickness
                    });
            } else {
                Road last = Roads.Last();
                AddJunction(direction);
                if (direction == Direction.Right) {
                    if (last.Direction == Direction.Down)
                        Roads.Add(new Road(direction) {
                            Left = last.Left + RoadThickness,
                            Top = last.Top + last.Distance,
                            Distance = distance,
                            Thickness = RoadThickness
                        });
                    if (last.Direction == Direction.Up)
                        Roads.Add(new Road(direction) {
                            Left = last.Left + RoadThickness,
                            Top = last.Top - RoadThickness,
                            Distance = distance,
                            Thickness = RoadThickness
                        });
                }

                if (direction == Direction.Left) {
                    if (last.Direction == Direction.Down)
                        Roads.Add(new Road(direction) {
                            Left = last.Left - last.Distance,
                            Top = last.Top + last.Distance,
                            Distance = distance,
                            Thickness = RoadThickness
                        });
                    if (last.Direction == Direction.Up)
                        Roads.Add(new Road(direction) {
                            Left = last.Left - last.Distance,
                            Top = last.Top - RoadThickness,
                            Distance = distance,
                            Thickness = RoadThickness
                        });
                }

                if (direction == Direction.Down) {
                    if (last.Direction == Direction.Right)
                        Roads.Add(new Road(direction) {
                            Left = last.Left + last.Distance,
                            Top = last.Top + RoadThickness,
                            Distance = distance,
                            Thickness = RoadThickness
                        });
                    if (last.Direction == Direction.Left)
                        Roads.Add(new Road(direction) {
                            Left = last.Left - RoadThickness,
                            Top = last.Top + RoadThickness,
                            Distance = distance,
                            Thickness = RoadThickness
                        });
                }

                if (direction == Direction.Up) {
                    if (last.Direction == Direction.Right)
                        Roads.Add(new Road(direction) {
                            Left = last.Left + last.Distance,
                            Top = last.Top - distance,
                            Distance = distance,
                            Thickness = RoadThickness
                        });
                    if (last.Direction == Direction.Left)
                        Roads.Add(new Road(direction) {
                            Left = last.Left - RoadThickness,
                            Top = last.Top - distance,
                            Distance = distance,
                            Thickness = RoadThickness
                        });
                }
            }

            EndDirection = direction;
            Road last1 = Roads.Last();
            if (last1.Direction == Direction.Right)
                End = new PointF(last1.Left + last1.Distance, last1.Top + RoadThickness / 2);
            else if (last1.Direction == Direction.Left)
                End = new PointF(last1.Left, last1.Top + RoadThickness / 2);
            else if (last1.Direction == Direction.Down)
                End = new PointF(last1.Left + RoadThickness / 2, last1.Top + last1.Distance);
            else if (last1.Direction == Direction.Up)
                End = new PointF(last1.Left + RoadThickness / 2, last1.Top);
        }

        private void AddJunction(Direction direction) {
            Road last = Roads.Last();
            if (direction == Direction.Right) {
                if (last.Direction == Direction.Up)
                    Junctions.Add(new Junction(320) {
                        Left = last.Left,
                        Top = last.Top - RoadThickness,
                        Width = RoadThickness
                    });
                else if (last.Direction == Direction.Down)
                    Junctions.Add(new Junction(40) {
                        Left = last.Left,
                        Top = last.Top + last.Distance,
                        Width = RoadThickness
                    });
                //else
                //    throw "Cant add junction to " + direction.ToString() + "
            } else if (direction == Direction.Left) {
                if (last.Direction == Direction.Up)
                    Junctions.Add(new Junction(220) {
                        Left = last.Left,
                        Top = last.Top - RoadThickness,
                        Width = RoadThickness
                    });
                else if (last.Direction == Direction.Down)
                    Junctions.Add(new Junction(140) {
                        Left = last.Left,
                        Top = last.Top + last.Distance,
                        Width = RoadThickness
                    });
                //else
                //    throw "Cant add junction to " + direction.ToString() + "
            } else if (direction == Direction.Up) {
                if (last.Direction == Direction.Right)
                    Junctions.Add(new Junction(310) {
                        Left = last.Left + last.Distance,
                        Top = last.Top,
                        Width = RoadThickness
                    });
                else if (last.Direction == Direction.Left)
                    Junctions.Add(new Junction(140) {
                        Left = last.Left + last.Distance,
                        Top = last.Top,
                        Width = RoadThickness
                    });
                //else
                //    throw "Cant add junction to " + direction.ToString() + "
            } else if (direction == Direction.Down) {
                if (last.Direction == Direction.Right)
                    Junctions.Add(new Junction(50) {
                        Left = last.Left + last.Distance,
                        Top = last.Top,
                        Width = RoadThickness
                    });
                else if (last.Direction == Direction.Left)
                    Junctions.Add(new Junction(130) {
                        Left = last.Left - RoadThickness,
                        Top = last.Top,
                        Width = RoadThickness
                    });
                //else
                //    throw "Cant add junction to " + direction.ToString() + "
            }
        }

        public Vector MoveOnRoad(PointF center, float distance, double currentAngle, int angleShiftDegree)
        {
            Road road = null;
            foreach (var item in Roads)
            {
                if (item.IsInside(center))
                {
                    road = item;
                    break;
                }
            }
            if (road != null)
            {
                return road.Move(center, distance, currentAngle, angleShiftDegree);
            }
            else
            {
                Junction juntion = null;
                foreach (var item in Junctions)
                {
                    if (center.X > item.Left && center.X < item.Left + item.Width && center.Y > item.Top && center.Y < item.Top + item.Width)
                    {
                        juntion = item;
                        break;
                    }
                }
                if (juntion != null)
                {
                    return juntion.Move(center, distance);
                }
            }

            return new Vector() { Point = center, Angle = currentAngle };
        }
    }

    public class Road {
        public float Top { get; set; }
        public float Left { get; set; }
        public float Thickness { get; set; }
        public float Distance { get; set; }

        Random rnd = new Random();

        public Direction Direction { get; set; }

        //public int Angle { get; set; }
        protected double _angle { get; set; }

        public Road(Direction direction) {
            Direction = direction;

            _angle = GetDefaultAngle();

        }

        public double GetDefaultAngle() {
            double angle;
            switch (Direction) {
                case Direction.Up:
                    angle = Calc.DegreeToRadian(270);
                    break;
                case Direction.Down:
                    angle = Calc.DegreeToRadian(90);
                    break;
                case Direction.Left:
                    angle = Calc.DegreeToRadian(180);
                    break;
                default:
                    angle = Calc.DegreeToRadian(0);
                    break;
            }

            return angle;

        }

        public Vector Move(PointF center, float distance, double currentAngle, int angleShiftDegree) {
            if (Direction == Direction.Up && center.Y < Top - distance - 0.1)
                currentAngle = Calc.DegreeToRadian(270);
            else if (Direction == Direction.Down && center.Y < Top + distance + 0.1)
                currentAngle = Calc.DegreeToRadian(90);
            else if (Direction == Direction.Left && center.X < Top - distance - 0.1)
                currentAngle = Calc.DegreeToRadian(180);
            else if (Direction == Direction.Right && center.X < Left + distance + 0.1)
                currentAngle = Calc.DegreeToRadian(0);


            double angleShift = Calc.DegreeToRadian(rnd.Next(angleShiftDegree));
            angleShift = rnd.Next(angleShiftDegree) % 2 == 0 ? angleShift : -angleShift;

            double moveAngle = currentAngle + angleShift;
            PointF temp = Calc.GetPoint(center, moveAngle, distance);

            if (!IsInside(temp)) {
                moveAngle = moveAngle - angleShift;
                temp = Calc.GetPoint(center, moveAngle, distance);
            }

            if (!IsInside(temp)) {
                moveAngle = _angle;
                temp = Calc.GetPoint(center, moveAngle, distance);
            }

            return new Vector() {Angle = moveAngle, Point = temp};

        }

        public bool IsInside(PointF temp) {
            if ((Direction == Direction.Up || Direction == Direction.Down) && temp.X > Left &&
                temp.X < Left + Thickness && temp.Y > Top && temp.Y < Top + Distance)
                return true;
            else if ((Direction == Direction.Left || Direction == Direction.Right) && temp.X > Left &&
                     temp.X < Left + Distance && temp.Y > Top && temp.Y < Top + Thickness)
                return true;

            return false;
        }

        public void DrawSelf(Graphics gfx, Pen pen) {
            if (Direction == Direction.Left || Direction == Direction.Right) {
                gfx.DrawLine(pen, Left, Top, Left + Distance, Top);
                gfx.DrawLine(pen, Left, Top + Thickness, Left + Distance, Top + Thickness);
            } else {
                gfx.DrawLine(pen, Left, Top, Left, Top + Distance);
                gfx.DrawLine(pen, Left + Thickness, Top, Left + Thickness, Top + Distance);
            }
        }
    }

    public class Junction {
        public float Top { get; set; }
        public float Left { get; set; }
        public float Width { get; set; }

        public Direction InDirection { get; set; }
        public Direction OutDirection { get; set; }
        public int Angle { get; set; }
        protected double _angle { get; set; }

        public Junction(int angle) {
            //InDirection = inDir;
            //OutDirection = outDir;
            Angle = angle;
            _angle = Calc.DegreeToRadian(angle);
        }

        public Vector Move(PointF center, float distance) {
            PointF temp = Calc.GetPoint(center, _angle, distance);

            return new Vector() {Angle = _angle, Point = temp};
        }


        public bool IsInside(PointF temp) {
            if (temp.X > Left && temp.X < Left + Width && temp.Y > Top && temp.Y < Top + Width)
                return true;

            return false;
        }


        public void DrawSelf(Graphics gfx, Pen pen) {
            gfx.DrawRectangle(new Pen(Brushes.BlueViolet), Left, Top, Width, Width);
        }
    }
}
