using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices;

/// <summary>
/// Interface for handling calls to an external AI service
/// </summary>
public interface IAIService
{
    /// <summary>
    /// Sends a request to the AI service and returns the response
    /// </summary>
    /// <param name="input">The input string to send to the AI service</param>
    /// <returns>The response from the AI service</returns>
    Task<string> GetResponseAsync(string input);

    /// <summary>
    /// Trains the AI model with the provided training data
    /// </summary>
    /// <param name="trainingData">The training data to use for training the AI model</param>
    Task TrainModelAsync(IEnumerable<string> trainingData);

    /// <summary>
    /// Saves the current AI model to the specified path
    /// </summary>
    /// <param name="modelPath">The path to save the AI model</param>
    Task SaveModelAsync(string modelPath);

    /// <summary>
    /// Loads an AI model from the specified path
    /// </summary>
    /// <param name="modelPath">The path to load the AI model from</param>
    Task LoadModelAsync(string modelPath);
}
