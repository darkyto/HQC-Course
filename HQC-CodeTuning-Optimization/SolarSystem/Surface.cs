namespace Surfaces
{
    using System;
    using System.Windows;
    using System.Windows.Media.Media3D;

    public abstract class Surface : ModelVisual3D
    {
        private static PropertyHolder<Material, Surface> materialProperty =
            new PropertyHolder<Material, Surface>("Material", null, OnMaterialChanged);

        private static PropertyHolder<Material, Surface> backMaterialProperty =
            new PropertyHolder<Material, Surface>("BackMaterial", null, OnBackMaterialChanged);

        private static PropertyHolder<bool, Surface> visibleProperty =
            new PropertyHolder<bool, Surface>("Visible", true, OnVisibleChanged);

        public Surface()
        {
            Content = _content;
            _content.Geometry = CreateMesh();
        }

        public Material Material
        {
            get { return materialProperty.Get(this); }
            set { materialProperty.Set(this, value); }
        }

        public Material BackMaterial
        {
            get { return backMaterialProperty.Get(this); }

            set { backMaterialProperty.Set(this, value); }
        }

        public bool Visible
        {
            get { return visibleProperty.Get(this); }

            set { visibleProperty.Set(this, value); }
        }

        private static void OnMaterialChanged(
            Object sender, 
            DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnMaterialChanged();
        }

        private static void OnBackMaterialChanged(
            Object sender, 
            DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnBackMaterialChanged();
        }

        private static void OnVisibleChanged(
            Object sender, 
            DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnVisibleChanged();
        }

        protected static void OnGeometryChanged(
            Object sender, 
            DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnGeometryChanged();
        }

        private void OnMaterialChanged()
        {
            SetContentMaterial();
        }

        private void OnBackMaterialChanged()
        {
            SetContentBackMaterial();
        }

        private void OnVisibleChanged()
        {
            SetContentMaterial();
            SetContentBackMaterial();
        }

        private void SetContentMaterial()
        {
            _content.Material = Visible ? Material : null;
        }

        private void SetContentBackMaterial()
        {
            _content.BackMaterial = Visible ? BackMaterial : null;
        }

        private void OnGeometryChanged()
        {
            _content.Geometry = CreateMesh();
        }

        protected abstract Geometry3D CreateMesh();

        private readonly GeometryModel3D _content = new GeometryModel3D();
    }
}