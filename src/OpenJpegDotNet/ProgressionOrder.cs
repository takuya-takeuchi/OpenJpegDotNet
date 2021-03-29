namespace OpenJpegDotNet
{

    /// <summary>
    /// Specifies the progression order.
    /// </summary>
    public enum ProgressionOrder
    {

        /// <summary>
        /// Specifies that place-holder. 
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Specifies that layer-resolution-component-precinct order. 
        /// </summary>
        LayerResolutionComponentPrecinct = 0,

        /// <summary>
        /// Specifies that resolution-layer-component-precinct order. 
        /// </summary>
        ResolutionLayerComponentPrecinct = 1,

        /// <summary>
        /// Specifies that resolution-precinct-component-layer order. 
        /// </summary>
        ResolutionPrecinctComponentLayer = 2,

        /// <summary>
        /// Specifies that precinct-component-resolution-layer order. 
        /// </summary>
        PrecinctComponentResolutionLayer = 3,

        /// <summary>
        /// Specifies that component-precinct-resolution-layer order.
        /// </summary>
        ComponentPrecinctResolutionLayer = 4

    }

}