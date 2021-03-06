﻿namespace Surfaces
{
    using System;
    using System.Windows.Media.Media3D;

    public sealed class Circle : Surface
    {
        private static PropertyHolder<double, Circle> radiusProperty =
            new PropertyHolder<double, Circle>("Radius", 1.0, OnGeometryChanged);

        private static PropertyHolder<Point3D, Circle> positionProperty =
            new PropertyHolder<Point3D, Circle>("Position", new Point3D(0, 0, 0), OnGeometryChanged);

        public Point3D Position
        {
            get { return positionProperty.Get(this); }
            set { positionProperty.Set(this, value); }
        }

        public double Radius
        {
            get { return radiusProperty.Get(this); }
            set { radiusProperty.Set(this, value); }
        }

        private double _radius;
        private Point3D _position;

        private Point3D PointForAngle(double angle)
        {
            return new Point3D(_position.X + _radius * Math.Cos(angle), _position.Y + _radius * Math.Sin(angle), _position.Z);
        }

        protected override Geometry3D CreateMesh()
        {
            this._radius = Radius;
            this._position = Position;

            MeshGeometry3D mesh = new MeshGeometry3D();
            Point3D prevPoint = PointForAngle(0);
            Vector3D normal = new Vector3D(0, 0, 1);

            const int div = 180;
            for (int i = 1; i <= div; ++i)
            {
                double angle = 2 * Math.PI / div * i;
                Point3D newPoint = PointForAngle(angle);
                mesh.Positions.Add(prevPoint);
                mesh.Positions.Add(_position);
                mesh.Positions.Add(newPoint);
                mesh.Normals.Add(normal);
                mesh.Normals.Add(normal);
                mesh.Normals.Add(normal);
                prevPoint = newPoint;
            }

            mesh.Freeze();
            return mesh;
        }
    }
}